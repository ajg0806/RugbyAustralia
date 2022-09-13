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

        public ImporterExporter(
              IEventQuery eventQuery
            , IFixtureQuery fixtureQuery
            , IPlayerQuery playerQuery
            , IEventRepository eventRepository
            , IFixtureRepository fixtureRepository
            , IPlayerRepository playerRepository
            , IDirectoryManager directoryManager
            )
        {
            _eventQuery = eventQuery;
            _fixtureQuery = fixtureQuery;
            _playerQuery = playerQuery;
            _eventRepository = eventRepository;
            _fixtureRepository = fixtureRepository;
            _playerRepository = playerRepository;
            _directoryManager = directoryManager;
            _directoryManager.SetRootPath(@"C:\Users\grabs\Documents\SoftwareDataEngineerTask");
        }
        public void ImportData()
        {
            if (!(_directoryManager.PlayersFileExists()))
                throw new ArgumentNullException("");
            if (!_directoryManager.FixturesFileExists())
                throw new ArgumentNullException("");
            if (!_directoryManager.EventsFolderExists())
            {
                if (_directoryManager.EventsArchiveExists())
                    _directoryManager.UnzipEventsArchive();
                else
                    throw new ArgumentNullException("");
            }
            if(!_directoryManager.EventsFileExists())
                throw new ArgumentNullException("");

            string root = _directoryManager.GetRootPath();
                _fixtureDtos = _fixtureQuery.RetriveFixtures($"{root}\\fixtures.csv");
                _playerDtos = _playerQuery.RetrivePlayers($"{root}\\players.csv");
                _eventDtos = _eventQuery.RetriveEvents($"{root}\\events\\events.csv");
        }
        public void ExportData()
        {
            _eventRepository.BulkInsert(_eventDtos.Select(x => EventMapper.Map(x)).ToList());
            _fixtureRepository.BulkInsert(_fixtureDtos.Select(x => FixtureMapper.Map(x)).ToList());
            _playerRepository.BulkInsert(_playerDtos.Select(x => PlayerMapper.Map(x)).ToList());
        }
    }
}
