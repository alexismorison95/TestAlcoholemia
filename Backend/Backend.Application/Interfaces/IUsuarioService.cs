﻿using Backend.Application.DTOs.Usuarios;
using Backend.Core.Entities;

namespace Backend.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<GetUsuarioDTO>> GetUsuarios();
        Task<UsuarioDTO> InsertUsuario(UsuarioDTO pUsuario);
        Task<UsuarioDTO> UpdateUsuario(UsuarioDTO pUsuario);
        Task<UsuarioDTO?> DeleteUsuario(string pNombreusuario);
    }
}
