using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public partial class Tipousuario
    {
        public Tipousuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
