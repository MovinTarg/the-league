using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Lost_in_the_Woods.Factory;
using MySql.Data.MySqlClient;
using The_Dojo_League.Models;

namespace The_Dojo_League.Factory
{
    public class DojoFactory : IFactory<Dojo>
    {
        private string connectionString;
        public DojoFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=The_Dojo_League;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public IEnumerable<Dojo> GetAllDojos()
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = @"SELECT * FROM dojos";
                dbConnection.Open();
                return dbConnection.Query<Dojo>(query).ToList();
            }
        }
        public Dojo FindDojo(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var query =
                @"
                SELECT * FROM dojos WHERE Id = @Id;
                SELECT * FROM ninjas WHERE dojo_id = @Id;
                ";
                using (var multi = dbConnection.QueryMultiple(query, new {Id = id}))
                {
                    var dojo = multi.Read<Dojo>().Single();
                    dojo.ninjas = multi.Read<Ninja>().ToList();
                    return dojo;
                }
            }
        }
        public void AddNewDojo(Dojo dojo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = @"INSERT INTO dojos (Name, Location, Info, CreatedAt, UpdatedAt) VALUES (@Name, @Location, @Info, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, dojo);
            }
        }
        public void Banish(int ninjaId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"UPDATE ninjas SET dojo_id = 1 WHERE Id = {ninjaId};";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
        public void Recruit(int dojoId, int ninjaId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"UPDATE ninjas SET dojo_id = {dojoId} WHERE Id = {ninjaId};";
                dbConnection.Open();
                dbConnection.Execute(query);
            }
        }
    }
}