using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Repositories;
using RugbyAustralia.InfrastructureServices.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Text;

namespace RugbyAustralia.InfrastructureServices.Repositories
{
    public class FixtureRepository : IFixtureRepository
    {
        protected readonly DbSet<Fixture> DbSet;

        public FixtureRepository(RugbyAustraliaContext context)
        {
            DbSet = context.Fixtures;
        }

        public void BulkInsert(IEnumerable<Fixture> fixtures)
        {
            DbSet.AddRange(fixtures);
        }

        public void Insert(Fixture fixture)
        {
            using SqlConnection connection = new SqlConnection("server=(local);database=RugbyAustralia;trusted_connection=true;");
            string query = "INSERT INTO Fixture (Fixture_Mid, Season, Competition_Name, Fixture_Datetime, Fixture_Round, Home_Team, Away_Team) VALUES(@Fixture_Mid, @Season, @Competition_Name, @Fixture_Datetime, @Fixture_Round, @Home_Team, @Away_Team)";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Fixture_Mid", fixture.Fixture_Mid);
            command.Parameters.AddWithValue("@Season", fixture.Season);
            command.Parameters.AddWithValue("@Competition_Name", fixture.Competition_Name);
            command.Parameters.AddWithValue("@Fixture_Datetime", fixture.Fixture_Datetime);
            command.Parameters.AddWithValue("@Fixture_Round", fixture.Fixture_Round);
            command.Parameters.AddWithValue("@Home_Team", fixture.Home_Team);
            command.Parameters.AddWithValue("@Away_Team", fixture.Away_Team);

            connection.Open();
            int result = command.ExecuteNonQuery();

            // Check Error
            if (result < 0)
                Console.WriteLine("Error inserting data into Database!");

            connection.Close();
        }
    }
}
