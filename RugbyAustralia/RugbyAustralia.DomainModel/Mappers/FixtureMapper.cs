using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Mappers
{
    public static class FixtureMapper
    {
        public static Fixture Map(FixtureDto dto)
        {
            return new Fixture {
                Fixture_Mid = dto.fixture_mid,
                Season = dto.season,
                Competition_Name = dto.competition_name,
                Fixture_Datetime = dto.fixture_round,
                Fixture_Round = dto.fixture_round,
                Home_Team = dto.home_team,
                Away_Team = dto.away_team
            };
        }
    }
}
