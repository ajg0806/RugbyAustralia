using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RugbyAustralia.DomainModel.Models
{
    public class Event
    {
        [Key]
        [Column(Order = 1)]
        public string Fixture_Id {get; set;}
        [Key]
        [Column(Order = 2)]
        public int Fixture_Event_Id {get; set;}
        public int Match_Half {get; set;}
        public int Match_Time {get; set;}
        public string Team {get; set;}
        public string Player_Id	{get; set;}
        public string Position_Number {get; set;}
        public int Shirt_Number {get; set;}
        public int Sequence_Number {get; set;}
        public int Possession_Number {get; set;}
        public int Phase_Number {get; set;}
        public string EvEnt {get; set;}
        public string Eventtype {get; set;}
        public string Eventresult {get; set;}
        public string Qualifier3 {get; set;}
        public string Qualifier4 {get; set;}
        public string Qualifier5 {get; set;}
        public int Value {get; set;}
        [ForeignKey("Fixture_Id")]
        public virtual Fixture Fixture { get; set; }
        [ForeignKey("Player_Id")]
        public virtual Player Player { get; set; }
    }
}
