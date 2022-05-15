using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pruebas = new HashSet<Prueba>();
        }

        public string Nombreusuario { get; set; } = null!;
        public bool Activo { get; set; }
        public string Nombrereal { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public int? Tipousuarioid { get; set; }

        public virtual Tipousuario? Tipousuario { get; set; }
        public virtual Examinador? Examinador { get; set; }
        public virtual ICollection<Prueba> Pruebas { get; set; }
    }
}
