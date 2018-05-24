using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Lost_in_the_Woods.Factory;
using MySql.Data.MySqlClient;
using The_Dojo_League.Models;

namespace The_Dojo_League.Factory
{
    public class NinjaFactory : IFactory<Ninja>
    {
        private string connectionString;
        public NinjaFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=The_Dojo_League;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        public IEnumerable<Ninja> GetAllNinjas()
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id = dojos.Id";
                dbConnection.Open();
                var allNinjas = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.ElDojo = dojo; return ninja; });
                return allNinjas;
            }
        }
        public IEnumerable<Ninja> RogueNinjas()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = "SELECT * FROM ninjas WHERE dojo_id = 1;";
                dbConnection.Open();
                return dbConnection.Query<Ninja>(query).ToList();
            }
        }
        public Ninja FindNinja(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                    string query = $"SELECT * FROM ninjas JOIN dojos ON ninjas.dojo_id = dojos.Id WHERE ninjas.Id = {id}";
                    dbConnection.Open();
                    var targetNinja = dbConnection.Query<Ninja, Dojo, Ninja>(query, (ninja, dojo) => { ninja.ElDojo = dojo; return ninja; });
                    return targetNinja.Single();
            }
        }
        public void AddNewNinja(Ninja ninja)
        {
            using (IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    string query = @"INSERT INTO ninjas (Name, Level, Description, dojo_id, CreatedAt, UpdatedAt) 
                    VALUES (@Name, @Level, @Description, @dojo_id, NOW(), NOW())";
                    dbConnection.Open();
                    dbConnection.Execute(query, ninja);
                }
            }
        }
    }
}