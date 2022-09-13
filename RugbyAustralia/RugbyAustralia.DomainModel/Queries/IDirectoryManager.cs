using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Queries
{
    public interface IDirectoryManager
    {
        void SetRootPath(string rootPath);
        string GetRootPath();
        bool PlayersFileExists();
        bool FixturesFileExists();
        bool EventsFolderExists();
        bool EventsArchiveExists();
        bool EventsFileExists();
        void UnzipEventsArchive();
    }
}
