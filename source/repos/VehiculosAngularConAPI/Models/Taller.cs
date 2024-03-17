using System;
using System.Collections.Generic;

namespace VehiculosAngularConAPI.Models
{
    public partial class Taller
    {
        public Taller()
        {
            Mantenimientos = new HashSet<Mantenimiento>();
        }

        public int IdTaller { get; set; }
        public string? Rut { get; set; }
        public string? NombreRz { get; set; }
        public string? NombreResponsable { get; set; }
        public string? Direccion { get; set; }
        public string? Fono { get; set; }
        public string? Correo { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Mantenimiento> Mantenimientos { get; set; }
    }
}
