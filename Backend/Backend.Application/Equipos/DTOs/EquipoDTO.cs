
namespace Backend.Application.Equipos.DTOs
{
    public class EquipoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool? Activo { get; set; }
        public int? Nroactual { get; set; }
    }
}
