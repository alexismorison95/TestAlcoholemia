using Backend.Application.DTOs.Usuarios;
using Backend.Core.Entities;

namespace Backend.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioTipoUsuarioDTO>> GetUsuarios();
        Task<UsuarioDTO> InsertUsuario(UsuarioDTO pUsuario);
        Task<UsuarioDTO> UpdateUsuario(UsuarioDTO pUsuario);
        Task<UsuarioDTO?> DeleteUsuario(string pNombreusuario);

        //tipo de usuario
        Task<IEnumerable<TipoUsuarioDTO>> GetTipoUsuario();
        Task<TipoUsuarioDTO> InsertTipoUsuario(TipoUsuarioDTO pTipoUsuario);
        Task<TipoUsuarioDTO?> DeleteTipoUsuario(int pId);
    }
}
