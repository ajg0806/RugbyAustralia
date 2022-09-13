using RugbyAustralia.CrossCuttingConcerns;
using RugbyAustralia.DomainModel;
using RugbyAustralia.DomainModel.Queries;
using System;

namespace RugbsyAustralia.ApplicationServices
{
    class Program
    {
        static void Main(string[] args)
        {
            CompositionRoot.Configure();
            CompositionRoot.GetInstance<IImporterExporter>().ImportData();
        }
    }
}
