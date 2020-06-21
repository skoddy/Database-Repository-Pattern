using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DatabaseApp
{
    public static class Extensions
    {
        public static List<MySqlParameter> ObjectToParameterList<T>(this T obj) where T : new()
        {
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            MySqlParameter parameter;

            IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();

            foreach (var property in properties)
            {
                parameter = new MySqlParameter("@" + property.Name, property.GetValue(obj)); //property.PropertyType.Name
                parameters.Add(parameter);
            }

            return parameters;
        }
    }
}

