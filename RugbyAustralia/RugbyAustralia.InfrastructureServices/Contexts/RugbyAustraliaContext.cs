using RugbyAustralia.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Contexts
{
    public class RugbyAustraliaContext : DbContext
    {
        public RugbyAustraliaContext(string ConnectionString) : base(ConnectionString) 
        { 
        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
