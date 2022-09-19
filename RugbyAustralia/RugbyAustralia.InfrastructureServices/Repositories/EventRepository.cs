using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Repositories;
using RugbyAustralia.InfrastructureServices.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace RugbyAustralia.InfrastructureServices.Repositories
{
    public class EventRepository : IEventRepository
    {
        protected readonly DbSet<Event> DbSet;

        public EventRepository(RugbyAustraliaContext context)
        {
            DbSet = context.Events;
        }
        public void BulkInsert(IEnumerable<Event> events)
        {
            DbSet.AddRange(events);
        }
    }
}
