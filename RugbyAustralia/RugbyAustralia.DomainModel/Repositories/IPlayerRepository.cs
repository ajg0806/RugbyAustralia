using RugbyAustralia.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Repositories
{
    public interface IPlayerRepository
    {
        void BulkInsert(IEnumerable<Player> player);
        void Insert(Player player);
    }
}
