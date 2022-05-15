using Backend.Application.DTOs.Usuarios;
using Backend.Core.Entities;

namespace Backend.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<GetUsuarioDTO>> GetUsuarios();
        Task<Usuario> InsertUsuario(UsuarioDTO pUsuario);
        Task UpdateUsuario(Usuario pUsuario);
        Task DeleteUsuario(Usuario pUsuario);
    }
}
