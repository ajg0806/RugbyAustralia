using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Dtos
{
    public class PlayerDto
    {
        [Name("player_mid")]
        public string player_mid {get; set;}
        [Name("player_name")]
        public string player_name {get; set;}
    }
}
