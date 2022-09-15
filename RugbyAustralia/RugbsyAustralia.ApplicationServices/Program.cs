using RugbyAustralia.CrossCuttingConcerns;
using RugbyAustralia.DomainModel;
using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace RugbsyAustralia.ApplicationServices
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SqlConnection connection = new SqlConnection("server=(local);database=RugbyAustralia;trusted_connection=true;");
                connection.Open();
                
            }
            catch(Exception ex)
            {
                
            }
            CompositionRoot.Configure();
            var ImporterExporter = CompositionRoot.GetInstance<IImporterExporter>();
            ImporterExporter.ImportData();
            ImporterExporter.ExportData();
        }
    }
}
