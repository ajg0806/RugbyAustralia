using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Repositories
{
    public class FixtureRepository : IFixtureRepository
    {
        public void BulkInsert(IEnumerable<Fixture> fixture)
        {
            throw new NotImplementedException();
        }
    }
}
