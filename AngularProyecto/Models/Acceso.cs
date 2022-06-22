using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProyecto.Models
{
    public class Acceso
    {
        public class AccesoUsuario
        {
            public int IdAcceso { get; set; }
            public string Usuario { get; set; }
            public string Contraseña { get; set; }
            public int IdPermiso { get; set; }
            public int IdPerson { get; set; }
            public bool Estado { get; set; }
        }
        public class AcceResultado
        {
            public string ResultadoFinal { get; set; }
            public int IdAcceso { get; set; }
            public string Usuario { get; set; }
            public int IdPersona { get; set; }
            public string PNombre { get; set; }
            public string SNombre { get; set; }
            public string PApellido { get; set; }
            public string SApellido { get; set; }
            public int IdPermiso { get; set; }
            public string Descripcion { get; set; }
        }
    }
}
