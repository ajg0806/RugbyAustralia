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
    public class FixtureQuery : IFixtureQuery
    {
        public IEnumerable<FixtureDto> RetriveFixtures(string filepath)
        {
            List<FixtureDto> fixtures;

            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.CurrentCulture))
            {
                fixtures = csv.GetRecords<FixtureDto>().ToList();
            }
            return fixtures;
        }
    }
}
