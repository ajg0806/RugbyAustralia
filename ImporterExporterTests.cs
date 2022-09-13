using Moq;
using NUnit.Framework;
using RugbyAustralia.DomainModel;
using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Queries;
using RugbyAustralia.DomainModel.Repositories;
using System.Collections.Generic;

namespace RugbyAustralia.DomainTests
{
    [TestFixture]
    public class ImporterExporterTests
    {
        private Mock<IDirectoryManager> _mockDirectoryManager;
        private Mock<IEventQuery> _mockEventQuery;
        private Mock<IFixtureQuery> _mockFixtureQuery;
        private Mock<IPlayerQuery> _mockPlayerQuery;
        private Mock<IPlayerRepository> _mockPlayerRepository;
        private Mock<IFixtureRepository> _mockFixtureRepository;
        private Mock<IEventRepository> _mockEventRepository;

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
            _mockDirectoryManager.Setup(mockManager => mockManager.SetRootPath(It.IsAny<string>())).Verifiable();
            _mockDirectoryManager.Setup(mockManager => mockManager.GetRootPath()).Returns("");
            _mockDirectoryManager.Setup(mockManager => mockManager.UnzipEventsArchive()).Verifiable();
            _mockEventQuery.Setup(mockEventQuery => mockEventQuery.RetriveEvents(It.IsAny<string>())).Returns(new List<EventDto>()).Verifiable();
            _mockFixtureQuery.Setup(mockFixtureQuery => mockFixtureQuery.RetriveFixtures(It.IsAny<string>())).Returns(new List<FixtureDto>()).Verifiable();
            _mockPlayerQuery.Setup(mockPlayerQuery => mockPlayerQuery.RetrivePlayers(It.IsAny<string>())).Returns(new List<PlayerDto>()).Verifiable();
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
                , _mockPlayerRepository.Object,
                "");
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
                , _mockPlayerRepository.Object,
                "");
            importerExporter.ImportData();
            _mockDirectoryManager.Verify(mockyManager => mockyManager.UnzipEventsArchive(), Times.Once());
            _mockPlayerQuery.Verify(mockPlayerQuery => mockPlayerQuery.RetrivePlayers(It.IsAny<string>()), Times.Once());
            _mockFixtureQuery.Verify(mockFixtureQuery => mockFixtureQuery.RetriveFixtures(It.IsAny<string>()), Times.Once());
            _mockEventQuery.Verify(mockEventQuery => mockEventQuery.RetriveEvents(It.IsAny<string>()), Times.Once());
        }
    }
}
