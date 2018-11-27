using System;
using System.Collections.Generic;//Para list<>
using System.Text;
using System.Threading.Tasks;//Para Task
using Entities;//Para la clase Alumno
using MySql.Data.MySqlClient;//Para MySqlConnection
using Dapper;//Para .QueryAsync<> (Linea 22) 
using System.Linq;//Para .ToList (Linea 23) 
//Revisar ASYNC y AWAIT https://msdn.microsoft.com/es-es/library/hh191443(v=vs.120)

namespace DataAccess
{
    public class AlumnoDAL : Connection
    {
        public async Task<string> InsertAlumnoAsync(Alumno Alumno)//Insertar un alumno asíncrono | Task<string>: devuelve una cadena
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            string Sql;//cadena que contendrá la consulta SQL
            string Dni = Alumno.Dni;//Parámetro recibido del objeto de clase Alumno
            string Nombres = Alumno.Nombres;//Parámetro recibido del objeto de clase Alumno
            string Apellidos = Alumno.Apellidos;//Parámetro recibido del objeto de clase Alumno
            string Email = Alumno.Email;//Parámetro recibido del objeto de clase Alumno
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta

            try
            {
                if (connection != null)//Si la conexion esta establecida
                {
                    Sql = @"INSERT INTO talumnos (Dni, Nombres, Apellidos, Email ) VALUES ('"+Dni+"','"+Nombres+"','"+Apellidos+"','"+Email+"')";//Consulta cargando los datos para el INSERT
                    FilasAfectadas = await connection.ExecuteAsync(Sql);//Ejecutamos la consulta
                }
                return "Se ha logrado insertar una fila";//Mensaje de confirmación
            }
            catch(Exception ex)//Exception ex : nos permite ver el error por el cual no se ha ejecutado la sentencia
            {
                Console.WriteLine("Error Consultando: " + ex.Message);//El programa devuelve un mensaje con el error
                return "no se ha logrado insertar";//Mensaje de denegación
            }
        }

        public async Task<List<Alumno>> GetAlumnosAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                List<Alumno> AlumnosList = null;//Se crea una lista de tipo Alumno
                if (connection != null)//Si la conexion esta establecida
                {
                    AlumnosList = (await connection.QueryAsync<Alumno>//Ejecuta una consulta asincrona
                        (@"SELECT IdAlumno, Dni, Nombres, Apellidos, Email FROM talumnos")).ToList();//Agrega el objeto obtenido de la consulta a la lista
                }
                return AlumnosList;//Retorna la lista para ser mostrada
            }
            catch
            {
                return null;//Si falla retorna nulo
            }
        }

        public async Task<Alumno> GetOneAlumnoAsync(int IdAlumno)//Obtener un solo alumno
        {
            MySqlConnection connection = base.OpenConnection();//Se llama al método OpenConnection de la clase connection
            try
            {
                Alumno Alumno1 = null;//Se crea un objeto de tipo Alumno
                if(connection != null)//Si la conexion esta establecida
                {
                    Alumno1 = await connection.QueryFirstAsync<Alumno>//Consulta para obtener un solo alumno segun el IdAlumno
                        (@"SELECT IdAlumno, Dni, Nombres, Apellidos, Email FROM talumnos WHERE IdAlumno = @IdAlumno", new
                        {
                            //IdAlumno = IdAlumno
                            IdAlumno
                        });
                }
                return Alumno1;//Si se realiza la consulta, retornamos el objeto de clase Alumno
            }
            catch
            {
                return null;//Si falla retornamos null
            }
        }

        public async Task<string> UpdateAlumnoAsync(Alumno Alumno)//Actualizar alumno asíncrono con Task<> | Recibe un objeto Alumno 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;//cadena que contendrá la sentencia SQL
            int FilasAfectadas;//entero que puede mostrar las filas afectadas al momento de hacer la consulta
            int IdAlumno = Alumno.IdAlumno;//Parámetro recibido del objeto de clase Alumno
            string Dni = Alumno.Dni;//Parámetro recibido del objeto de clase Alumno
            string Nombres = Alumno.Nombres;//Parámetro recibido del objeto de clase Alumno
            string Apellidos = Alumno.Apellidos;//Parámetro recibido del objeto de clase Alumno
            string Email = Alumno.Email;//Parámetro recibido del objeto de clase Alumno
            try
            {
                if (connection != null)
                {
                    Sql = "UPDATE talumnos SET Dni ='"+Dni+"', Nombres = '"+Nombres+"', Apellidos = '"+Apellidos+"', Email = '"+Email+"' WHERE IdAlumno = '"+IdAlumno+"'";//Consulta con los datos cargados
                    FilasAfectadas = await connection.ExecuteAsync(Sql);// Se ejecuta la consulta
                }
                return "Se ha actualizado correctamente la tabla alumnos";// Mensaje de confirmación
            }
            catch
            {
                return "No se ha podido actualizar el registro";//Mensaje de denegación
            }
        }

        public async Task<string> DeleteAlumnoAsync(int IdAlumno)//Eliminar alumno asíncrono. Task<> 
        {
            MySqlConnection connection = base.OpenConnection();
            string Sql;
            int FilasAfectadas;
            try
            {
                Sql = "DELETE FROM talumnos WHERE IdAlumno = '"+IdAlumno+"'";//Consulta SQL para eliminar
                FilasAfectadas = await connection.ExecuteAsync(Sql);//Se ejecuta
                return "Se ha eliminado el registro de la tabla alumnos";//Aceptado
            }
            catch
            {
                return "No se ha podido eliminar el registro";//Denegado
            }
        }

    }
}
