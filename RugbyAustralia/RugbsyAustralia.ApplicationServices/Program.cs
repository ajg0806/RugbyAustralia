using RugbyAustralia.CrossCuttingConcerns;
using RugbyAustralia.DomainModel;
using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Queries;
using RugbyAustralia.DomainModel.Repositories;
using System;
using System.Collections.Generic;

namespace RugbsyAustralia.ApplicationServices
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositionRoot.Configure();
            var ImporterExporter = CompositionRoot.GetInstance<IImporterExporter>();
            ImporterExporter.ImportData();
            ImporterExporter.ExportData();
        }
    }
}
