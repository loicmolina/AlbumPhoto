using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AlbumPhoto.BDD
{
    class BDD
    {
        private static MySqlConnection _connection;
        private static MySqlCommand _cmd;

        private static void InitConnection()
        {
            String connectionString = "SERVER=localhost; UID=root;PASSWORD=;";

            _connection = new MySqlConnection(connectionString);

            _cmd = new MySqlCommand();

            try
            {
                //Creation de connection
                _cmd.Connection = _connection;

                _cmd.Connection.Open();

                Console.WriteLine("Connection opened");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Error : {0}", ex.ToString());
                throw ex;
            }

        }
        
        private static void creerDB()
        {
            _cmd.CommandText = "CREATE DATABASE albumphotobdd";

            try
            {
                _cmd.ExecuteNonQuery();

                Console.WriteLine("Database created");
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Error : {0}",ex.ToString());
            }


        }

        public static void test()
        {
            InitConnection();
            creerDB();
        }
    }
}
