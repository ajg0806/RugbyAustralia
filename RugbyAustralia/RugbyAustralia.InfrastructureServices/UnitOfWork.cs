using RugbyAustralia.DomainModel;
using RugbyAustralia.InfrastructureServices.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RugbyAustralia.InfrastructureServices
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RugbyAustraliaContext _rugbyAustraliaContext;
        public UnitOfWork(RugbyAustraliaContext rugbyAustraliaContext)
        {
            _rugbyAustraliaContext = rugbyAustraliaContext;
        }
        public void Save()
        {
            _rugbyAustraliaContext.SaveChanges();
        }
    }
}
