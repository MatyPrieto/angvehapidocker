using System;
using System.Collections.Generic;

namespace VehiculosAngularConAPI.Models
{
    public partial class VehiculoCarrocerium
    {
        public VehiculoCarrocerium()
        {
            Modelos = new HashSet<Modelo>();
        }

        public int IdCarroceria { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
