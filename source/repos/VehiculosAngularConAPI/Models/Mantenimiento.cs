using System;
using System.Collections.Generic;

namespace VehiculosAngularConAPI.Models
{
    public partial class Mantenimiento
    {
        public int IdMantenimiento { get; set; }
        public string? Descripcion { get; set; }
        public DateOnly? FechaInicio { get; set; }
        public DateOnly? FechaTermino { get; set; }
        public string? PatenteForanea { get; set; }
        public int? IdTaller { get; set; }
        public int? TrabajadorId { get; set; }

        public virtual Taller? IdTallerNavigation { get; set; }
        public virtual Trabajador? Trabajador { get; set; }
    }
}
