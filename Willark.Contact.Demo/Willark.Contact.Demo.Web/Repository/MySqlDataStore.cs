using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Willark.Contact.Demo.Models;

namespace Willark.Contact.Demo.Web.Repository
{
    public class MySqlDataStore : IItemRepository
    {
        private static string _connectionString = "Server=sql9.freemysqlhosting.net;port=3306;Database=sql9364925;Uid=sql9364925;Pwd=9KQBnyDPp6;SslMode=Preferred";

        public MySqlDataStore()
        {
        }

        public void Add(Item item)
        {
            using (MySqlConnection _conn = new MySqlConnection(_connectionString))
            {
                _conn.Open();
                _conn.Insert(item);
            }
        }

        public Item Get(string id)
        {
            using (MySqlConnection _conn = new MySqlConnection(_connectionString))
            {
                return _conn.Get<Item>(id);
            }
        }

        public IEnumerable<Item> GetAll()
        {
            using (var _conn = new MySqlConnection(_connectionString))
            {
                var sql = "SELECT Id, Text, Description FROM Item";
                return _conn.Query<Item>(sql).ToList();
            }
        }

        public Item Remove(string key)
        {
            Item item = null;
            using (var _conn = new MySqlConnection(_connectionString))
            {
                item = Get(key);
                _conn.Execute("DELETE FROM Item Where Id = @Id", new { Id = key });
            }

            return item;
        }

        public void Update(Item item)
        {
            using (var _conn = new MySqlConnection(_connectionString))
            {
                _conn.Update<Item>(item);
            }
        }
    }
}
