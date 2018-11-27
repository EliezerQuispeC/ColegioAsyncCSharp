using System;

namespace Entities
{
    public class Alumno
    {
        public int IdAlumno { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("ID={0} , DNI={1}, NOMBRES={2}, APELLIDOS={3}, EMAIL={4}", this.IdAlumno, this.Dni, this.Nombres, this.Apellidos, this.Email);
        }
    }
}
