using System;
using System.Collections.Generic;

namespace VehiculosAngularConAPI.Models
{
    public partial class Trabajador
    {
        public Trabajador()
        {
            Mantenimientos = new HashSet<Mantenimiento>();
        }

        public int IdTrabajador { get; set; }
        public string? Rut { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoP { get; set; }
        public string? ApellidoM { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Mantenimiento> Mantenimientos { get; set; }
    }
}
