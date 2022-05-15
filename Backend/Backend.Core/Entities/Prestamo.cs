using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public partial class Prestamo
    {
        public Prestamo()
        {
            Pruebas = new HashSet<Prueba>();
        }

        public int Id { get; set; }
        public bool? Activo { get; set; }
        public DateOnly Fechaprestamo { get; set; }
        public TimeOnly Horaprestamo { get; set; }
        public int Nroinicial { get; set; }
        public DateOnly? Fechadevolucion { get; set; }
        public TimeOnly? Horadevolucion { get; set; }
        public int? Nrodevolucion { get; set; }
        public int? Examinadorid { get; set; }
        public int? Equipoid { get; set; }

        public virtual Equipo? Equipo { get; set; }
        public virtual Examinador? Examinador { get; set; }
        public virtual ICollection<Prueba> Pruebas { get; set; }
    }
}
