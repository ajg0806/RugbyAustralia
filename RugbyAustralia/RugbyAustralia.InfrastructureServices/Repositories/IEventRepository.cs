using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Repositories
{
    public class EventRepository : IEventRepository
    {
        public void BulkInsert(IEnumerable<Event> evnt)
        {
            throw new NotImplementedException();
        }
    }
}
