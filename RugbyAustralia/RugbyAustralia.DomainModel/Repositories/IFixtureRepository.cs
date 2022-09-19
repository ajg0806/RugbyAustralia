using RugbyAustralia.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Repositories
{
    public interface IFixtureRepository
    {
        void BulkInsert(IEnumerable<Fixture> fixture);
    }
}
