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
    public class PlayerQuery : IPlayerQuery
    {
        public IEnumerable<PlayerDto> RetrivePlayers(string filepath)
        {
            List<PlayerDto> players;

            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
            {
                players = csv.GetRecords<PlayerDto>().ToList();
            }
            return players;
        }
    }
}
