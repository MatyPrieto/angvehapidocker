using System;
using System.Collections.Generic;

namespace VehiculosAngularConAPI.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string? Rut { get; set; }
        public string? Nombre { get; set; }
        public string? Password { get; set; }
        public string? Correo { get; set; }
        public string? Fono { get; set; }
        public bool? Estado { get; set; }
    }
}
