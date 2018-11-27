using System;
using Entities;//Para clase Alumno
using System.Collections.Generic;//Para List<>
using System.Threading.Tasks;//Para Task
using DataAccess;//Para AlumnoDAL

namespace BusinessLayer
{
    public class AlumnoBL
    {
        AlumnoDAL dal = new AlumnoDAL();//variable dal de clase AlumnoDAL para ejecutar todas las funciones de esta clase
        //TOdas las funciones estan en AlumnoDAL, enviamos los parámetros necesarios para cada función
        public async Task<string> InsertAlumnoAsync(Alumno Alumno)//Task: operacion asincrona q devuelve un valor <value>
        {
            string respuesta = await dal.InsertAlumnoAsync(Alumno);//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return respuesta;//retorna una cadena
        }
        public async Task<List<Alumno>> GetAlumnosAsync()//Task: operacion asincrona q devuelve un valor <value>
        {
            List<Alumno> Alumnos = await dal.GetAlumnosAsync();//await: el método asincrónico no puede continuar hasta que se complete el proceso 
            return Alumnos;//retorna una lista
        }
        public async Task<Alumno> GetOneAlumnoAsync(int IdAlumno)
        {
            Alumno Alumno = await dal.GetOneAlumnoAsync(IdAlumno);
            return Alumno;//retorna un objeto de clase Alumno
        }
        public async Task<string> UpdateAlumnoAsync(Alumno Alumno)
        {
            string respuesta = await dal.UpdateAlumnoAsync(Alumno);
            return respuesta;//retorna una cadena
        }
        public async Task<string> DeleteAlumnoAsync(int IdAlumno)
        {
            string respuesta = await dal.DeleteAlumnoAsync(IdAlumno);
            return respuesta;//retorna una cadena
        }
    }
}
