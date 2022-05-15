using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public partial class Dominio
    {
        public Dominio()
        {
            Pruebas = new HashSet<Prueba>();
        }

        public string Patente { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Prueba> Pruebas { get; set; }
    }
}
