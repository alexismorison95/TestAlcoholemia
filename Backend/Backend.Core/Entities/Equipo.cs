using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public partial class Equipo
    {
        public Equipo()
        {
            Periodoutilizables = new HashSet<Periodoutilizable>();
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool? Activo { get; set; }
        public int? Nroactual { get; set; }

        public virtual ICollection<Periodoutilizable> Periodoutilizables { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
