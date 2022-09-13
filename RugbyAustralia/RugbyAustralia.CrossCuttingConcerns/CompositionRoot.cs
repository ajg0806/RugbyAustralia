using System;
using IContainer = StructureMap.IContainer;
using Container = StructureMap.Container;
using RugbyAustralia.DomainModel.Queries;
using RugbyAustralia.InfrastructureServices.Queries;
using RugbyAustralia.DomainModel.Repositories;
using RugbyAustralia.InfrastructureServices.Repositories;
using RugbyAustralia.DomainModel;

namespace RugbyAustralia.CrossCuttingConcerns
{
    public static class CompositionRoot
    {
        private static IContainer Container;
        public static void Configure()
        {
            Container = new Container( config => 
            {
                config.For<IDirectoryManager>().Use<DirectoryManager>();
                config.For<IEventQuery>().Use<EventQuery>();
                config.For<IFixtureQuery>().Use<FixtureQuery>();
                config.For<IPlayerQuery>().Use<PlayerQuery>();
                config.For<IEventRepository>().Use<EventRepository>();
                config.For<IFixtureRepository>().Use<FixtureRepository>();
                config.For<IPlayerRepository>().Use<PlayerRepository>();
                config.For<IImporterExporter>().Use<ImporterExporter>();
            });
        }
        public static T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }
    }
}
