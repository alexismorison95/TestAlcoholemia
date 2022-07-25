﻿using Backend.Application.Usuarios.DTOs;
using Backend.Core.Entities;

namespace Backend.Application.Interfaces
{
    public interface IUsuarioService
    {
        //usuarios
        Task<IEnumerable<UsuarioDTO>> GetUsuarios();
        Task<IEnumerable<UsuarioExtendedDTO>> GetUsuariosExtended();
        Task<UsuarioDTO> InsertUsuario(UsuarioDTO pUsuario);
        Task<UsuarioDTO> UpdateUsuario(UsuarioDTO pUsuario);
        Task<UsuarioDTO?> DeleteUsuario(string pNombreusuario);

        //tipo de usuario
        Task<IEnumerable<TipoUsuarioDTO>> GetTipoUsuario();
    }
}
