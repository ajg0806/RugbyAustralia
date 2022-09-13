using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Queries;
using RugbyAustralia.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RugbyAustralia.DomainModel
{
    public interface IImporterExporter
    {
        void ImportData();
        void ExportData();
    }
}
