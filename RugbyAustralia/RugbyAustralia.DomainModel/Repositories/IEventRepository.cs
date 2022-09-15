using RugbyAustralia.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Repositories
{
    public interface IEventRepository
    {
        void BulkInsert(IEnumerable<Event> evnt);
        void Insert(Event @event);
    }
}
