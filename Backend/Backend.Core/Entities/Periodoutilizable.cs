using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public partial class Periodoutilizable
    {
        public int Id { get; set; }
        public bool? Activo { get; set; }
        public DateOnly Fechainicio { get; set; }
        public DateOnly Fechavencimiento { get; set; }
        public int Nroingreso { get; set; }
        public int? Equipoid { get; set; }

        public virtual Equipo? Equipo { get; set; }
    }
}
