using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace DatabaseApp
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly Database db;

        public CustomerRepository()
        {
            db = new Database();
        }

        public List<Customer> GetAll()
        {
            string sql = "SELECT * FROM Customers";

            List<Customer> list = new List<Customer>();

            MySqlDataReader reader = db.Execute(sql);

            while (reader.Read())
            {
                list.Add(Populate(reader));
            }
            db.Close();

            return list;
        }

        public Customer GetById(int id)
        {
            string sql = string.Format("SELECT * FROM Customers WHERE CustomerID={0}", id);

            Customer customer = new Customer();

            MySqlDataReader reader = db.Execute(sql);

            while (reader.Read())
            {
                customer = Populate(reader);
            }
            db.Close();

            return customer;
        }

        public void Insert(Customer model)
        {
            List<MySqlParameter> parameters = model.ObjectToParameterList();

            string sql = 
                "INSERT INTO Customers (CompanyName, City, Country) " +
                "VALUES(@CompanyName, @City, @Country)";

            db.Execute(sql, parameters);
            db.Close();
        }

        public void Update(Customer model)
        {
            string sql = 
                "UPDATE Customers " +
                "SET CompanyName=@CompanyName, City=@City, Country=@Country " +
                "WHERE CustomerID=@CustomerID";

            List<MySqlParameter> parameters = model.ObjectToParameterList();

            db.Execute(sql, parameters);
            db.Close();
        }

        public void Delete(int id)
        {
            string sql = string.Format("DELETE FROM Customers WHERE CustomerID={0}", id);

            db.Execute(sql);
            db.Close();
        }

        protected Customer Populate(MySqlDataReader reader)
        {
            Customer customer = new Customer
            {
                CustomerID = reader.GetInt32("CustomerID"),
                CompanyName = reader.IsDBNull("CompanyName") ? "" : reader.GetString("CompanyName"),
                City = reader.IsDBNull("City") ? "" : reader.GetString("City"),
                Country = reader.IsDBNull("Country") ? "" : reader.GetString("Country")
            };

            return customer;
        }
    }
}
