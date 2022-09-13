using RugbyAustralia.DomainModel.Dtos;
using RugbyAustralia.DomainModel.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Queries
{
    public class PlayerQuery : IPlayerQuery
    {
        public IEnumerable<PlayerDto> RetrivePlayers(string filepath)
        {
            throw new NotImplementedException();
        }
    }
}
