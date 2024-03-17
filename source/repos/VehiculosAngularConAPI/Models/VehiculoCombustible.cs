using System;
using System.Collections.Generic;

namespace VehiculosAngularConAPI.Models
{
    public partial class VehiculoCombustible
    {
        public VehiculoCombustible()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int IdCombustible { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
