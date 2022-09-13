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
            return new Fixture();
        }
    }
}
