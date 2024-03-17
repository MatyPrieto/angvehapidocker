using System;
using System.Collections.Generic;

namespace VehiculosAngularConAPI.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
