using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Dtos
{
    public class FixtureDto
    {
        [Name("fixture_mid")]
        public string fixture_mid { get; set; }
        [Name("season")]
        public string season { get; set; }
        [Name("competition_name")]
        public string competition_name { get; set; }
        [Name("fixture_datetime")]
        public string fixture_datetime { get; set; }
        [Name("fixture_round")]
        public string fixture_round { get; set; }
        [Name("home_team")]
        public string home_team { get; set; }
        [Name("away_team")]
        public string away_team { get; set; }
    }
}
