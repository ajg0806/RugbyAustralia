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
    public class PlayerRepository : IPlayerRepository
    {
        protected readonly DbSet<Player> DbSet;

        public PlayerRepository(RugbyAustraliaContext context)
        {
            DbSet = context.Players;
        }
        public void BulkInsert(IEnumerable<Player> players)
        {
            DbSet.AddRange(players);
        }
    }
}
