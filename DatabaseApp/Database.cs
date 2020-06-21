using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseApp
{
    public class Database
    {
        protected MySqlConnection connection = null;
        protected string command { set; get; }
        protected List<MySqlParameter> parameters { set; get; }
        private static string connectionString = GetConnectionString();


        public MySqlDataReader Execute(string commandName, List<MySqlParameter> parameters = null)
        {
            Database db = new Database();

            db.command = commandName;
            db.parameters = parameters;

            return db.ExecuteCommand();

        }

        protected MySqlDataReader ExecuteCommand()
        {
            MySqlCommand command = new MySqlCommand();
            MySqlDataReader dataReader = null;

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                command.CommandType = CommandType.Text;
                command.Connection = connection;
                command.CommandText = this.command;

                if (parameters != null)
                {
                    foreach (MySqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    command.Prepare();
                }

                dataReader = command.ExecuteReader();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return dataReader;

        }


        public void Close()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }

        static private string GetConnectionString()
        {
            return "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=business";
        }

    }
}
