using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public partial class Conductor
    {
        public Conductor()
        {
            Pruebas = new HashSet<Prueba>();
        }

        public string Dni { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;

        public virtual ICollection<Prueba> Pruebas { get; set; }
    }
}
