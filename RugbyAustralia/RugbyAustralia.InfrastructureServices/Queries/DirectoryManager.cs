using RugbyAustralia.DomainModel.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Queries
{
    public class DirectoryManager : IDirectoryManager
    {
        private string _rootPath;

        public bool EventsArchiveExists()
        {
            return File.Exists($"{_rootPath}\\events.zip");
        }

        public bool EventsFileExists()
        {
            return File.Exists($"{_rootPath}\\events\\events.csv");
        }

        public bool EventsFolderExists()
        {
            return Directory.Exists($"{_rootPath}\\events");
        }

        public bool FixturesFileExists()
        {
            return File.Exists($"{_rootPath}\\fixtures.csv");
        }

        public string GetRootPath()
        {
            return _rootPath;
        }

        public bool PlayersFileExists()
        {
            return File.Exists($"{_rootPath}\\players.csv");
        }

        public void SetRootPath(string rootPath)
        {
            _rootPath = rootPath;
        }

        public void UnzipEventsArchive()
        {
            ZipFile.ExtractToDirectory($"{_rootPath}\\events.zip", _rootPath);
        }
    }
}
