using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Dtos
{
    public class EventDto
    {
        [Name("fixture_id")]
        public string fixture_id {get; set;}
        [Name("fixture_event_id")]
        public int fixture_event_id {get; set;}
        [Name("match_half")]
        public int match_half {get; set;}
        [Name("match_time")]
        public int match_time {get; set;}
        [Name("team")]
        public string team {get; set;}
        [Name("player_id")]
        public string player_id	{get; set;}
        [Name("position_number")]
        public string position_number {get; set;}
        [Name("shirt_number")]
        public int shirt_number {get; set;}
        [Name("sequence_number")]
        public int sequence_number {get; set;}
        [Name("possession_number")]
        public int possession_number {get; set;}
        [Name("phase_number")]
        public int phase_number {get; set;}
        [Name("event")]
        public string evnt {get; set;}
        [Name("eventtype")]
        public string eventtype {get; set;}
        [Name("eventresult")]
        public string eventresult {get; set;}
        [Name("qualifier3")]
        public string qualifier3 {get; set;}
        [Name("qualifier4")]
        public string qualifier4 {get; set;}
        [Name("qualifier5")]
        public string qualifier5 {get; set;}
        [Name("value")]
        public int value {get; set;}
    }
}
