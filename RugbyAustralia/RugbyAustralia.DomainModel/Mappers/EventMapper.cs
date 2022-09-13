using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Mappers
{
    public static class EventMapper
    {
        public static Event Map(EventDto dto)
        {
            return new Event();
        }
    }
}
