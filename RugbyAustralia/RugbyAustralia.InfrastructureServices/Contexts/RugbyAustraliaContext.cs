using RugbyAustralia.DomainModel.Models;
using System.Data.Common;
using System.Data.Entity;

namespace RugbyAustralia.InfrastructureServices.Contexts
{
    public class RugbyAustraliaContext : DbContext
    {
        public RugbyAustraliaContext(DbConnection conn) : base(conn, true) {
        }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Fixture> Fixtures { get; set; }
        public virtual DbSet<Player> Players { get; set; }
    }
}
