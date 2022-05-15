
namespace Backend.Application.DTOs.Usuarios
{
    public class GetUsuarioDTO
    {
        public string Nombreusuario { get; set; } = null!;
        public bool Activo { get; set; }
        public string Nombrereal { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public string Tipousuario { get; set; } = null!;
    }
}
