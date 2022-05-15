using Backend.Application.DTOs.Usuarios;
using Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetUsuarios();
        Task InsertUsuario(Usuario pUsuario);
        Task UpdateUsuario(Usuario pUsuario);
        Task DeleteUsuario(Usuario pUsuario);
    }
}
