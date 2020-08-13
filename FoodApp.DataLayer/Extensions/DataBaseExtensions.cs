namespace FoodApp.DataLayer.Extensions
{
    using System.Data;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System;
    using System.Data.SqlClient;

    /// <summary>
    /// Clase de manejador de datos
    /// </summary>
    public static class DataBaseExtensions
    {
        /// <summary>
        /// Cadena de conexion configurada en el web config
        /// </summary>
        private static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["Chilaqueria"].ToString();
            }
        }

        /// <summary>
        /// Ejecuta un select en la base de datos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <param name="projection"></param>
        /// <returns></returns>
        public static List<T> Select<T>(this SqlCommand command, Func<IDataReader, T> projection)
        {
            var resultList = new List<T>();
            if (command != null)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Connection.Open();

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        resultList.Add(projection(reader));
                    }
                    reader.Close();
                }
            }
            return resultList;
        }

        /// <summary>
        /// Ejecuta la consulta a base sql y retorna un escalar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public static T Escalar<T>(this SqlCommand command)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Connection.Open();

                var reader = command?.ExecuteScalar().ToString();
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)converter.ConvertFrom(reader);
            }
        }

        /// <summary>
        /// Ejecuta un exec non query en la base de datos
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static bool ExecuteQuery(this SqlCommand command)
        {
            bool isQueryExecuted = default(bool);
            if (command != null)
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 0;
                    command.Connection.Open();
                    isQueryExecuted = command?.ExecuteNonQuery() > default(int);
                }
            }
            return isQueryExecuted;
        }

        /// <summary>
        /// Obtiene el valor de un dato dado, metodo extension
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T Get<T>(this IDataReader reader, string name)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                if (reader != null && converter != null && reader.GetOrdinal(name) >= default(int))
                {
                    return (T)converter.ConvertFromString(reader[name].ToString());
                }
                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

    }
}