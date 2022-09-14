using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel.Mappers
{
    public static class PlayerMapper
    {
        public static Player Map(PlayerDto dto)
        {
            return new Player 
            { 
                Player_Mid = dto.player_mid,
                Player_Name = dto.player_name
            };
        }
    }
}
