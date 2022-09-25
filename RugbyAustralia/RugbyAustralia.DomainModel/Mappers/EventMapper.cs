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
            int? value = GetValue(dto.value);

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
        public static int? GetValue(string valString)
        {
            int? value = null;
            if ((valString.All(char.IsDigit) ||
               (valString[0] == '-' &&
               valString[1..].All(char.IsDigit)))
               && valString.Length > 0)
                value = Int32.Parse(valString);
            else if (valString.Length > 0)
            {
                List<string> ops = new List<string>();
                List<int> numbers = new List<int>();
                SeperateParts(ops, numbers, valString);
                value = Math(ops, numbers);
            }
            return value;
        }
        public static int Math(List<string> ops, List<int> numbers)
        {
            int result = numbers.FirstOrDefault();
            numbers.RemoveAt(0);
            int i = 0;
            numbers.ForEach(n =>
            {
                if (ops.ElementAt(i) == "+")
                    result += n;
                else if (ops.ElementAt(i) == "-")
                    result -= n;
                i++;
            });
            return result;
        }
        public static void SeperateParts(List<string> ops, List<int> numbers, string str)
        {
            int s = 0;
            while (s < str.Length)
            {
                int l = 1;
                while (str.Substring(s, l).All(char.IsDigit)
                    && s + l < str.Length)
                    l++;
                string tmp = str.Substring(s, l);
                if (char.IsDigit(tmp[0]) && !tmp.All(char.IsDigit))
                    tmp = tmp[0..^1];
                if (tmp.All(char.IsDigit))
                    numbers.Add(Int32.Parse(tmp));
                else
                    ops.Add(tmp);
                s += tmp.Length;
            }
        }
    }
}
