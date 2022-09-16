using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RugbyAustralia.DomainModel.Models
{
    public class Event
    {
        [Key]
        public string Fixture_Id {get; set;}
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
    }
}
