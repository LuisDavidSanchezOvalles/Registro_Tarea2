using System;
using System.Collections.Generic;
using System.Text;

namespace Registro.Entidades
{
    public class Personas
    {
        public int PersonaId { set; get; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Personas()
        {
            PersonaId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Cedula = string.Empty;
            Direccion = string.Empty;
            FechaNacimiento = DateTime.Now;
        }

        public Personas(int personaId, string nombre, string telefono, string cedula, string direccion, DateTime fechaNacimiendo)
        {
            PersonaId = personaId;
            Nombre = nombre;
            Telefono = telefono;
            Cedula = cedula;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiendo;
        }
    }
}
