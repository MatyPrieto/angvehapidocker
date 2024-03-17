using System;
using System.Collections.Generic;

namespace VehiculosAngularConAPI.Models
{
    public partial class Vehiculo
    {
        public string Patente { get; set; } = null!;
        public string? DescripcionVehiculo { get; set; }
        public int? Anio { get; set; }
        public int? Capacidad { get; set; }
        public int? Aro { get; set; }
        public string? NumeroChasis { get; set; }
        public string? AceiteUtilizado { get; set; }
        public string? Bujia { get; set; }
        public string? PresionNeumatico { get; set; }
        public int? IdModelo { get; set; }

        public virtual Modelo? IdModeloNavigation { get; set; }
    }
}
