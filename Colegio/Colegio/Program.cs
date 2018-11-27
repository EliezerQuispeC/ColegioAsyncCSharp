using System;
using Entities;
using BusinessLayer;
using Dapper;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Colegio
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MainAsync().Wait();//Espera la tarea para completar la ejecución
            Console.ReadKey();
        }
        static async Task MainAsync()//Operación asíncrona (no sé porqué debemos poner las funciones aquí :V)
        {
            //INSERTAR UN ALUMNO
            Alumno alumno = new Alumno()//Instanciamos un alumno
            {
                Nombres = "Kike Kiko",
                Apellidos = "Merced",
                Dni = "44556677",
                Email = "kike@koke.com"
            };
            Console.WriteLine(await InsertAlumnoAsync(alumno));//llamamos a la funcion y al finalizar mostramos un mensaje

            //MOSTRAR TODOS LOS ALUMNOS
            List<Alumno> MiLista = await GetAlumnosAsync();//Lista de clase alumno y llamamos a la función
            foreach (var item in MiLista)//Recorremos la lista obtenida
            {
                Console.WriteLine(item);//Mostramos cada objeto de la lista
            }

            //MOSTRAR UN ALUMNO
            Console.WriteLine(await GetOneAlumnoAsync(1));//Enviamos el IdAlumno

            //ACTUALIZAR DATOS DE ALUMNO
            Alumno alumno1 = new Alumno()
            {
                IdAlumno = 10,
                Nombres = "Kristel",
                Apellidos = "Alvarez",
                Dni = "44556677",
                Email = "k@koke.com"
            };
            Console.WriteLine(await UpdateAlumnoAsync(alumno1));//Actualizamos un alumno enviandole todo un objeto Alumno
            //ELIMINAR ALUMNO
            Console.WriteLine(await DeleteAlumnoAsync(13));//Eliminamos el alumno enviando solo el Id
        }

        static AlumnoBL bl = new AlumnoBL();//variable dal de clase AlumnoBL para ejecutar todas las funciones de esta clase

        //Todas las funciones estan en AlumnoBL, enviamos los parámetros necesarios para cada función
        public static async Task<string> InsertAlumnoAsync(Alumno Alumno)
        {
            return await bl.InsertAlumnoAsync(Alumno);
        }
        public static async Task<List<Alumno>> GetAlumnosAsync()
        {
            return await bl.GetAlumnosAsync();
        }
        public static async Task<Alumno> GetOneAlumnoAsync(int IdAlumno)
        {
            return await bl.GetOneAlumnoAsync(IdAlumno);
        }
        public static async Task<string> UpdateAlumnoAsync(Alumno Alumno)
        {
            return await bl.UpdateAlumnoAsync(Alumno);
        }
        public static async Task<string> DeleteAlumnoAsync(int IdAlumno)
        {
            return await bl.DeleteAlumnoAsync(IdAlumno);
        }
        /*public static async void GetAllAlumnos_SinDapper()
        {
            string cadenaConexion = @"server = 127.0.0.1; uid = tecsup; pwd = Tecsup2018  ; database = bdcolegio";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            MySqlCommand command = new MySqlCommand("SELECT * FROM talumnos", conn);
            DbDataReader reader = await command.ExecuteReaderAsync();
            while (reader.Read())
            {
                int IdAlumno = reader.GetInt32(0);
                string Dni = reader.GetString(1);
                string Nombres = reader.GetString(2);
                string Apellidos = reader.GetString(3);
                string Email = reader.GetString(4);
                Console.WriteLine("ID = {4}, DNI = {0}, NOMBRES = {1}, APELLIDOS = {2}, EMAIL = {3}", Dni, Nombres, Apellidos, Email, IdAlumno);
            }
            conn.Close();
        }

        public static async void UpdateAlumno_SinDapper()
        {
            string cadenaConexion = @"server = 127.0.0.1; uid = tecsup; pwd = Tecsup2018  ; database = bdcolegio";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string sql = @"UPDATE talumnos SET Dni = '232323', Nombres = 'Maria' WHERE IdAlumno = 2";
            MySqlCommand command = new MySqlCommand(sql, conn);
            await command.ExecuteNonQueryAsync();
            conn.Close();
        }

        public static async void DeleteAlumno_SinDapper()
        {
            string cadenaConexion = @"server = 127.0.0.1; uid = tecsup; pwd = Tecsup2018  ; database = bdcolegio";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string sql = @"DELETE FROM talumnos WHERE IdAlumno = 5";
            MySqlCommand command = new MySqlCommand(sql, conn);
            await command.ExecuteNonQueryAsync();
            conn.Close();
        }

        public static async void GetAllAlumnos()
        {
            string cadenaConexion = @"server = 127.0.0.1; uid = tecsup; pwd = Tecsup2018; database = bdcolegio";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            IEnumerable<Alumno> alumnos = await conn.QueryAsync<Alumno>("SELECT * FROM talumnos");
            foreach (Alumno alumno in alumnos)
            {
                Console.WriteLine("ID = {0}, DNI = {1}, NOMBRES = {2}, APELLIDOS = {3}", alumno.IdAlumno, alumno.Dni, alumno.Nombres, alumno.Apellidos
                    );
            }
            conn.Close();
        }

        public static async void UpdateAlumno()
        {
            string cadenaConexion = @"server = 127.0.0.1; uid = tecsup; pwd = Tecsup2018; database = bdcolegio";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string sql = @"UPDATE talumnos SET Dni = '838383838', Nombres = 'Juano', Apellidos = 'Mira' WHERE IdAlumno = 2";
            int filasAfectadas = await conn.ExecuteAsync(sql);
            conn.Close();
        }
        public static async void DeleteAlumno()
        {
            string cadenaConexion = @"server = 127.0.0.1; uid = tecsup; pwd = Tecsup2018; database = bdcolegio";
            MySqlConnection conn = new MySqlConnection(cadenaConexion);
            conn.Open();
            string sql = @"DELETE FROM talumnos WHERE IdAlumno = 2";
            int filasAfectadas = await conn.ExecuteAsync(sql);
            conn.Close();
        }*/
    }
}
