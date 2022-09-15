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
    public class PlayerRepository : IPlayerRepository
    {
        protected readonly DbSet<Player> DbSet;

        public PlayerRepository(RugbyAustraliaContext context)
        {
            DbSet = context.Players;
        }
        public void BulkInsert(IEnumerable<Player> players)
        {
            DbSet.AddRange(players);
        }

        public void Insert(Player player)
        {

            using SqlConnection connection = new SqlConnection("server=(local);database=RugbyAustralia;trusted_connection=true;");
            string query = "INSERT INTO Player (Player_Mid, Player_Name) VALUES (@Player_Mid, @Player_Name);";

            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Player_Mid", player.Player_Mid);
            command.Parameters.AddWithValue("@Player_Name", player.Player_Name);

            connection.Open();
            int result = command.ExecuteNonQuery();

            // Check Error
            if (result < 0)
                Console.WriteLine("Error inserting data into Database!");

            connection.Close();
        }
    }
}
