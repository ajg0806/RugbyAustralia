using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Queries;
using RugbyAustralia.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using RugbyAustralia.DomainModel.Mappers;

namespace RugbyAustralia.DomainModel
{
    public class ImporterExporter : IImporterExporter
    {
        private readonly IEventQuery _eventQuery;
        private readonly IFixtureQuery _fixtureQuery;
        private readonly IPlayerQuery _playerQuery;
        private readonly IEventRepository _eventRepository;
        private readonly IFixtureRepository _fixtureRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IDirectoryManager _directoryManager;
        private IEnumerable<EventDto> _eventDtos;
        private IEnumerable<FixtureDto> _fixtureDtos;
        private IEnumerable<PlayerDto> _playerDtos;
        private IUnitOfWork _unitOfWork;

        public ImporterExporter(
              IEventQuery eventQuery
            , IFixtureQuery fixtureQuery
            , IPlayerQuery playerQuery
            , IEventRepository eventRepository
            , IFixtureRepository fixtureRepository
            , IPlayerRepository playerRepository
            , IDirectoryManager directoryManager
            , IUnitOfWork unitOfWork)
        {
            _eventQuery = eventQuery;
            _fixtureQuery = fixtureQuery;
            _playerQuery = playerQuery;
            _eventRepository = eventRepository;
            _fixtureRepository = fixtureRepository;
            _playerRepository = playerRepository;
            _directoryManager = directoryManager;
            _directoryManager.SetRootPath(@"C:\Users\grabs\Documents\SoftwareDataEngineerTask");
            _unitOfWork = unitOfWork;
        }
        public void ImportData()
        {
            if (!(_directoryManager.PlayersFileExists()))
                throw new ArgumentNullException("Player file does not exist.");
            if (!_directoryManager.FixturesFileExists())
                throw new ArgumentNullException("Fixture file does not exist.");
            if (!_directoryManager.EventsFolderExists())
            {
                if (_directoryManager.EventsArchiveExists())
                    _directoryManager.UnzipEventsArchive();
                else
                    throw new ArgumentNullException("Event archive does not exist.");
            }
            if(!_directoryManager.EventsFileExists())
                throw new ArgumentNullException("Event file does not exist.");

            string root = _directoryManager.GetRootPath();
                _fixtureDtos = _fixtureQuery.RetriveFixtures($"{root}\\fixtures.csv");
                _playerDtos = _playerQuery.RetrivePlayers($"{root}\\players.csv");
                _eventDtos = _eventQuery.RetriveEvents($"{root}\\events\\events.csv");
        }
        public void ExportData()
        {
            _playerRepository.BulkInsert(_playerDtos.ToList().Select(x => PlayerMapper.Map(x)));
            _fixtureRepository.BulkInsert(_fixtureDtos.ToList().Select(x => FixtureMapper.Map(x)));
            _eventRepository.BulkInsert(_eventDtos.ToList().Select(x => EventMapper.Map(x)));
            _unitOfWork.Save();
        }
    }
}
