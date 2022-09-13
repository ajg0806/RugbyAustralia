using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public void BulkInsert(IEnumerable<Player> player)
        {
            throw new NotImplementedException();
        }
    }
}
