using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProyecto.Models
{
    public class Personas
    {
        public int IdPersona { get; set; }
        public string Cedula { get; set; }
        public string PNombre { get; set; }
        public string SNombre { get; set; }
        public string PApellido { get; set; }
        public string SApelldio { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Celular { get; set; }
        public string Correo { get; set; }
        public string EstadoCivil { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
    }
}
