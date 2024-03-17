using System;
using System.Collections.Generic;

namespace VehiculosAngularConAPI.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdModelo { get; set; }
        public string? Descripcion { get; set; }
        public int? IdMarca { get; set; }
        public int? IdCombustible { get; set; }
        public int? IdCarroceria { get; set; }
        public bool? Estado { get; set; }

        public virtual VehiculoCarrocerium? IdCarroceriaNavigation { get; set; }
        public virtual VehiculoCombustible? IdCombustibleNavigation { get; set; }
        public virtual Marca? IdMarcaNavigation { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
