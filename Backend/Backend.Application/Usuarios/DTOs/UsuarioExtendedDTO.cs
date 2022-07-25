using Backend.Core.Entities;

namespace Backend.Application.Usuarios.DTOs
{
    public class UsuarioExtendedDTO : UsuarioDTO
    {
        public string Tipousuario { get; set; } = null!;
    }
}
