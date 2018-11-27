using System;
using MySql.Data.MySqlClient;//Para MySqlConnection

namespace DataAccess
{
    public class Connection
    {
        private string MySqlConnectionString = @"server = 127.0.0.1; uid = tecsup; pwd = Tecsup2018; database = bdcolegio";//string con la sentencia para conectar a la db
        public MySqlConnection OpenConnection() //método para abrir la conexion a la base de datos
        {
            try
            {
                using (MySqlConnection mysqlConnection = new MySqlConnection(this.MySqlConnectionString))//Representa una conexión abierta a una base de datos MySql
                {
                    if (mysqlConnection.State == System.Data.ConnectionState.Open)//Si la conexion esta abierta
                        return mysqlConnection;
                    else
                    {
                        mysqlConnection.Open();//Abrir la conexion
                        return mysqlConnection;
                    }
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
