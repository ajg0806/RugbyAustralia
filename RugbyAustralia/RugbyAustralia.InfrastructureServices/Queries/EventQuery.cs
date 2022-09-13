using CsvHelper;
using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Queries
{
    public class EventQuery : IEventQuery
    {
        public IEnumerable<EventDto> RetriveEvents(string filepath)
        {
            List<EventDto> events;

            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
            {
                events = csv.GetRecords<EventDto>().ToList();
            }
            return events;
        }
    }
}
