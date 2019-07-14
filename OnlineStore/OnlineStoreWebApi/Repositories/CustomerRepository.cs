using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using OnlineStoreWebApi.Models;

namespace OnlineStoreWebApi.Repositories
{
    public class CustomerRepository
    {
        public CustomerRepository()
        {
        }

        public IList<Customer> GetAll()
        {
            var onlineStoreDbUserName = "store"; // Environment.GetEnvironmentVariable("ONLINE_STORE_DB_USERNAME");
            var onlineStoreDbPassword = "password"; // Environment.GetEnvironmentVariable("ONLINE_STORE_DB_PASSWORD");
            var onlineStoreDbServer = "192.168.0.105"; // Environment.GetEnvironmentVariable("ONLINE_STORE_DB_SERVER");
            var onLineStoreDbName = "OnlineStore";

            var connectionString = $"Server={onlineStoreDbServer};Database={onLineStoreDbName};Uid={onlineStoreDbUserName};Pwd={onlineStoreDbPassword};SSL Mode = None;charset=utf8";

            MySqlConnection connection = new MySqlConnection(connectionString);

            var registeredCustomers = connection.Query<Customer>("Select * from Customers");
            return registeredCustomers.AsList();
        }
    }
}
