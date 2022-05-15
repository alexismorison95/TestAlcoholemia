using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public partial class Examinador
    {
        public Examinador()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int Id { get; set; }
        public bool? Activo { get; set; }
        public string? Usuarionombre { get; set; }

        public virtual Usuario? UsuarionombreNavigation { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
