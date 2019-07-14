using System;
using Dapper;
using MySql.Data.MySqlClient;
using OnlineStoreWorker.Models;

namespace OnlineStoreWorker.Repositories
{
    public class CustomerRepository
    {

        public CustomerRepository()
        {
        }


        public void Insert(Customer customer)
        {
            var onlineStoreDbUserName = "store"; // Environment.GetEnvironmentVariable("ONLINE_STORE_DB_USERNAME");
            var onlineStoreDbPassword = "password"; // Environment.GetEnvironmentVariable("ONLINE_STORE_DB_PASSWORD");
            var onlineStoreDbServer = "wetoMySQL"; // Environment.GetEnvironmentVariable("ONLINE_STORE_DB_SERVER");
            var onLineStoreDbName = "OnlineStore";

            var connectionString = $"Server={onlineStoreDbServer};Database={onLineStoreDbName};Uid={onlineStoreDbUserName};Pwd={onlineStoreDbPassword};SSL Mode = None;charset=utf8";

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);


                var count = connection.Execute(@"insert into Customers (FirstName, LastName,EmailAddress,NotifyMe) values (@FirstName, @LastName,@EmailAddress,@NotifyMe)",
                                               customer);
                Console.WriteLine("Se inserto registro para: " + customer.FirstName);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error en insert: " + ex.Message);
                Console.WriteLine("Datos: " + connectionString);
                throw ex;
            }
        }
    }
}
