using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Repositories;
using RugbyAustralia.InfrastructureServices.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Repositories
{
    public class FixtureRepository : IFixtureRepository
    {
        protected readonly DbSet<Fixture> DbSet;

        public FixtureRepository(RugbyAustraliaContext context)
        {
            DbSet = context.Fixtures;
        }

        public void BulkInsert(IEnumerable<Fixture> fixtures)
        {
            DbSet.AddRange(fixtures);
        }
    }
}
