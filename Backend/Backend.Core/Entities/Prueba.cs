using System;
using System.Collections.Generic;

namespace Backend.Core.Entities
{
    public partial class Prueba
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora { get; set; }
        public int Nromuestra { get; set; }
        public double Resultado { get; set; }
        public int? Nroacta { get; set; }
        public int? Nroretencion { get; set; }
        public bool? Verificado { get; set; }
        public bool? Rechazado { get; set; }
        public string? Descripcionrechazo { get; set; }
        public string? Verificadornombre { get; set; }
        public string? Conductordni { get; set; }
        public string? Dominioid { get; set; }
        public int? Prestamoid { get; set; }

        public virtual Conductor? ConductordniNavigation { get; set; }
        public virtual Dominio? Dominio { get; set; }
        public virtual Prestamo? Prestamo { get; set; }
        public virtual Usuario? VerificadornombreNavigation { get; set; }
    }
}
