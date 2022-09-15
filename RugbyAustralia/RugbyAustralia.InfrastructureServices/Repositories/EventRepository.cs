using RugbyAustralia.DomainModel.Models;
using RugbyAustralia.DomainModel.Repositories;
using RugbyAustralia.InfrastructureServices.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;

namespace RugbyAustralia.InfrastructureServices.Repositories
{
    public class EventRepository : IEventRepository
    {
        protected readonly DbSet<Event> DbSet;

        public EventRepository(RugbyAustraliaContext context)
        {
            DbSet = context.Events;
        }
        public void BulkInsert(IEnumerable<Event> events)
        {
            DbSet.AddRange(events);
        }

        public void Insert(Event @event)
        {
            using SqlConnection connection = new SqlConnection("server=(local);database=RugbyAustralia;trusted_connection=true;");
            string query = "INSERT INTO Event (Fixture_Id, Fixture_Event_Id, Match_Half, " +
                "Match_Time, Team, Player_Id, Position_Number, Shirt_Number, Sequence_Number, " +
                "Possession_Number, Phase_Number, EvEnt, Eventtype, Eventresult, Qualifier3, Qualifier4, Qualifier5, Value) " +
                "VALUES (@Fixture_Id, @Fixture_Event_Id, @Match_Half, @Match_Time, @Team, @Player_Id, @Position_Number, " +
                "@Shirt_Number, @Sequence_Number, @Possession_Number, @Phase_Number, @EvEnt, @Eventtype, @Eventresult, " +
                "@Qualifier3, @Qualifier4, @Qualifier5, @Value)";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Fixture_Id", @event.Fixture_Id);
            command.Parameters.AddWithValue("@Fixture_Event_Id", @event.Fixture_Event_Id);
            command.Parameters.AddWithValue("@Match_Half", @event.Match_Half);
            command.Parameters.AddWithValue("@Match_Time", @event.Match_Time);
            command.Parameters.AddWithValue("@Team", @event.Team);
            command.Parameters.AddWithValue("@Player_Id", @event.Player_Id);
            command.Parameters.AddWithValue("@Position_Number", @event.Position_Number);
            command.Parameters.AddWithValue("@Shirt_Number", @event.Shirt_Number);
            command.Parameters.AddWithValue("@Sequence_Number", @event.Sequence_Number);
            command.Parameters.AddWithValue("@Possession_Number", @event.Possession_Number);
            command.Parameters.AddWithValue("@Phase_Number", @event.Phase_Number);
            command.Parameters.AddWithValue("@EvEnt", @event.EvEnt);
            command.Parameters.AddWithValue("@Eventtype", @event.Eventtype);
            command.Parameters.AddWithValue("@Eventresult", @event.Eventresult);
            command.Parameters.AddWithValue("@Qualifier3", @event.Qualifier3);
            command.Parameters.AddWithValue("@Qualifier4", @event.Qualifier4);
            command.Parameters.AddWithValue("@Qualifier5", @event.Qualifier5);
            command.Parameters.AddWithValue("@Value", @event.Value);

            connection.Open();
            int result = command.ExecuteNonQuery();

            // Check Error
            if (result < 0)
                Console.WriteLine("Error inserting data into Database!");

            connection.Close();
        }
    }
}
