using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RugbyAustralia.DomainModel.Mappers
{
    public static class EventMapper
    {
        public static Event Map(EventDto dto)
        {
            int value;
            try
            {
                value = Int32.Parse(dto.value);
            }
            catch (Exception ex)
            {
                value = 0;

            }
            return new Event
            {
                Fixture_Id = dto.fixture_id,
                Fixture_Event_Id = dto.fixture_event_id,
                Match_Half = dto.match_half,
                Match_Time = dto.match_time,
                Team = dto.team,
                Player_Id = dto.player_id,
                Position_Number = dto.position_number,
                Shirt_Number = dto.shirt_number,
                Possession_Number = dto.possession_number,
                Phase_Number = dto.phase_number,
                EvEnt = dto.evnt,
                Eventtype = dto.eventtype,
                Eventresult = dto.eventresult,
                Qualifier3 = dto.qualifier3,
                Qualifier4 = dto.qualifier4,
                Qualifier5 = dto.qualifier5,
                Value = value
            };
        }
    }
}
