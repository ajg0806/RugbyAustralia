using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Queries
{
    public class EventQuery : IEventQuery
    {
        public IEnumerable<EventDto> RetriveEvents(string filepath)
        {
            throw new NotImplementedException();
        }
    }
}
