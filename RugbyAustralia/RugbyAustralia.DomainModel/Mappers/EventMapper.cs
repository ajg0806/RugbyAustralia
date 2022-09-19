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
            int? value = null;
            if ((dto.value.All(char.IsDigit) || 
                (dto.value[0] == '-' && 
                dto.value[1..].All(char.IsDigit)))  
                && dto.value.Length > 0)
                value = Int32.Parse(dto.value);
            else if (dto.value.Length > 0)
            {
                List<string> ops = new List<string>();
                List<int> numbers = new List<int>();
                int s = 0;
                while(s < dto.value.Length)
                {
                    int l = 1;
                    while (dto.value.Substring(s, l).All(char.IsDigit)
                        && s + l < dto.value.Length)
                        l++;
                    string tmp = dto.value.Substring(s, l);
                    if (char.IsDigit(tmp[0]) && !tmp.All(char.IsDigit))
                        tmp = tmp[0..^1];
                    if (tmp.All(char.IsDigit))
                        numbers.Add(Int32.Parse(tmp));
                    else
                        ops.Add(tmp);
                    s += tmp.Length;
                }
                int tmpNum = numbers.FirstOrDefault();
                numbers.RemoveAt(0);
                int i = 0;
                numbers.ForEach(n => 
                {
                    if (ops.ElementAt(i) == "+")
                        tmpNum += n;
                    else if (ops.ElementAt(i) == "-")
                        tmpNum -= n;
                    i++;
                });
                value = tmpNum;
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
