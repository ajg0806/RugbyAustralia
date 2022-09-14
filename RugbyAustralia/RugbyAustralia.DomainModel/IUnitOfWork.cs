using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.DomainModel
{
    public interface IUnitOfWork
    {
        void Save();
    }
}
