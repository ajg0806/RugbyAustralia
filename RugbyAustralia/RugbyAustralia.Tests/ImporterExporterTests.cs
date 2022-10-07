using Moq;
using NUnit.Framework;
using RugbyAustralia.DomainModel;
using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Queries;
using RugbyAustralia.DomainModel.Repositories;
using RugbyAustralia.InfrastructureServices;
using System;
using System.Collections.Generic;

namespace RugbyAustralia.Tests
{
    public class ImporterExporterTests
    {
        private Mock<IDirectoryManager> _mockDirectoryManager;
        private Mock<IEventQuery> _mockEventQuery;
        private Mock<IFixtureQuery> _mockFixtureQuery;
        private Mock<IPlayerQuery> _mockPlayerQuery;
        private Mock<IPlayerRepository> _mockPlayerRepository;
        private Mock<IFixtureRepository> _mockFixtureRepository;
        private Mock<IEventRepository> _mockEventRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        [SetUp]
        public void Setup()
        {
            _mockDirectoryManager = new Mock<IDirectoryManager>();
            _mockEventQuery = new Mock<IEventQuery>();
            _mockFixtureQuery = new Mock<IFixtureQuery>();
            _mockPlayerQuery = new Mock<IPlayerQuery>();
            _mockEventRepository = new Mock<IEventRepository>();
            _mockFixtureRepository = new Mock<IFixtureRepository>();
            _mockPlayerRepository = new Mock<IPlayerRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockDirectoryManager.Setup(mockManager => mockManager.SetRootPath(It.IsAny<string>())).Verifiable();
            _mockDirectoryManager.Setup(mockManager => mockManager.GetRootPath()).Returns("");
            _mockDirectoryManager.Setup(mockManager => mockManager.UnzipEventsArchive()).Verifiable();
            _mockEventQuery.Setup(mockEventQuery => mockEventQuery.RetriveEvents(It.IsAny<string>())).Returns(new List<EventDto>()).Verifiable();
            _mockFixtureQuery.Setup(mockFixtureQuery => mockFixtureQuery.RetriveFixtures(It.IsAny<string>())).Returns(new List<FixtureDto>()).Verifiable();
            _mockPlayerQuery.Setup(mockPlayerQuery => mockPlayerQuery.RetrivePlayers(It.IsAny<string>())).Returns(new List<PlayerDto>()).Verifiable();
            _mockEventRepository.Setup(mockEventRepo => mockEventRepo.BulkInsert(It.IsAny<IEnumerable<Event>>())).Verifiable();
            _mockFixtureRepository.Setup(mockEventRepo => mockEventRepo.BulkInsert(It.IsAny<IEnumerable<Fixture>>())).Verifiable();
            _mockPlayerRepository.Setup(mockEventRepo => mockEventRepo.BulkInsert(It.IsAny<IEnumerable<Player>>())).Verifiable();
        }
        [Test]
        public void ImporterExporter_AllDataRetrived()
        {
            _mockDirectoryManager.Setup(mockManager => mockManager.PlayersFileExists()).Returns(true);
            _mockDirectoryManager.Setup(mockManager => mockManager.FixturesFileExists()).Returns(true);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsFolderExists()).Returns(true);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsFileExists()).Returns(true);

            ImporterExporter importerExporter = new ImporterExporter(_mockEventQuery.Object
                , _mockFixtureQuery.Object
                , _mockPlayerQuery.Object
                , _mockEventRepository.Object
                , _mockFixtureRepository.Object
                , _mockPlayerRepository.Object
                , _mockDirectoryManager.Object
                , _mockUnitOfWork.Object
                );
            importerExporter.ImportData();
            _mockPlayerQuery.Verify(mockPlayerQuery => mockPlayerQuery.RetrivePlayers(It.IsAny<string>()), Times.Once());
            _mockFixtureQuery.Verify(mockFixtureQuery => mockFixtureQuery.RetriveFixtures(It.IsAny<string>()), Times.Once());
            _mockEventQuery.Verify(mockEventQuery => mockEventQuery.RetriveEvents(It.IsAny<string>()), Times.Once());
        }
        [Test]
        public void ImporterExporter_ArchiveNotUnzipped_ArchiveUnzipped_AllDataRetrived()
        {
            _mockDirectoryManager.Setup(mockManager => mockManager.PlayersFileExists()).Returns(true);
            _mockDirectoryManager.Setup(mockManager => mockManager.FixturesFileExists()).Returns(true);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsFolderExists()).Returns(false);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsArchiveExists()).Returns(true);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsFileExists()).Returns(true);

            ImporterExporter importerExporter = new ImporterExporter(_mockEventQuery.Object
                , _mockFixtureQuery.Object
                , _mockPlayerQuery.Object
                , _mockEventRepository.Object
                , _mockFixtureRepository.Object
                , _mockPlayerRepository.Object
                , _mockDirectoryManager.Object
                , _mockUnitOfWork.Object
                );

            importerExporter.ImportData();
            _mockDirectoryManager.Verify(mockyManager => mockyManager.UnzipEventsArchive(), Times.Once());
            _mockPlayerQuery.Verify(mockPlayerQuery => mockPlayerQuery.RetrivePlayers(It.IsAny<string>()), Times.Once());
            _mockFixtureQuery.Verify(mockFixtureQuery => mockFixtureQuery.RetriveFixtures(It.IsAny<string>()), Times.Once());
            _mockEventQuery.Verify(mockEventQuery => mockEventQuery.RetriveEvents(It.IsAny<string>()), Times.Once());
        }
        [TestCase (true, true, true, true, false)]
        [TestCase(true, true, false, false, false)]
        [TestCase(true, false, true, true, true)]
        [TestCase(false, true, true, true, true)]
        public void ImporterExporter_MissingData_ThrowsError(
            bool PlayerFilexExists
            , bool FixtureFileExists
            , bool EventFolderExists
            , bool EventArchiveExists
            , bool EventFileExists)
        {
            _mockDirectoryManager.Setup(mockManager => mockManager.PlayersFileExists()).Returns(PlayerFilexExists);
            _mockDirectoryManager.Setup(mockManager => mockManager.FixturesFileExists()).Returns(FixtureFileExists);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsFolderExists()).Returns(EventFolderExists);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsArchiveExists()).Returns(EventArchiveExists);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsFileExists()).Returns(EventFileExists);

            ImporterExporter importerExporter = new ImporterExporter(_mockEventQuery.Object
                , _mockFixtureQuery.Object
                , _mockPlayerQuery.Object
                , _mockEventRepository.Object
                , _mockFixtureRepository.Object
                , _mockPlayerRepository.Object
                , _mockDirectoryManager.Object
                , _mockUnitOfWork.Object
                );

            Assert.Throws<ArgumentNullException>(() => importerExporter.ImportData());

            _mockPlayerQuery.Verify(mockPlayerQuery => mockPlayerQuery.RetrivePlayers(It.IsAny<string>()), Times.Never());
            _mockFixtureQuery.Verify(mockFixtureQuery => mockFixtureQuery.RetriveFixtures(It.IsAny<string>()), Times.Never());
            _mockEventQuery.Verify(mockEventQuery => mockEventQuery.RetriveEvents(It.IsAny<string>()), Times.Never());
        }

        [Test]
        public void ImporterExporter__BulkInsertConclude()
        {
            _mockDirectoryManager.Setup(mockManager => mockManager.PlayersFileExists()).Returns(true);
            _mockDirectoryManager.Setup(mockManager => mockManager.FixturesFileExists()).Returns(true);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsFolderExists()).Returns(true);
            _mockDirectoryManager.Setup(mockManager => mockManager.EventsFileExists()).Returns(true);

            ImporterExporter importerExporter = new ImporterExporter(_mockEventQuery.Object
                , _mockFixtureQuery.Object
                , _mockPlayerQuery.Object
                , _mockEventRepository.Object
                , _mockFixtureRepository.Object
                , _mockPlayerRepository.Object
                , _mockDirectoryManager.Object
                , _mockUnitOfWork.Object
                );
            importerExporter.ImportData();
            importerExporter.ExportData();
            _mockEventRepository.Verify(mockEventRepo => mockEventRepo.BulkInsert(It.IsAny<IEnumerable<Event>>()), Times.Once());
            _mockFixtureRepository.Verify(mockEventRepo => mockEventRepo.BulkInsert(It.IsAny<IEnumerable<Fixture>>()), Times.Once());
            _mockPlayerRepository.Verify(mockEventRepo => mockEventRepo.BulkInsert(It.IsAny<IEnumerable<Player>>()), Times.Once());
        }
    }
}