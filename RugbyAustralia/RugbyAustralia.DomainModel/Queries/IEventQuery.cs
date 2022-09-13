using RugbyAustralia.DomainModel.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Queries
{
    public interface IEventQuery
    {
        IEnumerable<EventDto> RetriveEvents(string filepath);
    }
}
