using System;
using System.ComponentModel.DataAnnotations;

namespace RugbyAustralia.DomainModel.Models
{
    public class Fixture
    {
        [Key]
        public string Fixture_Mid { get; set; }
        public string Season { get; set; }
        public string Competition_Name { get; set; }
        public string Fixture_Datetime { get; set; }
        public string Fixture_Round { get; set; }
        public string Home_Team { get; set; }
        public string Away_Team { get; set; }
    }
}
