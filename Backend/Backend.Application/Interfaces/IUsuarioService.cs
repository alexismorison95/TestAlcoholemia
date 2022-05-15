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
        Task<IEnumerable<UsuarioDTO>> GetUsers();
        Task InsertUsusario(Usuario pUsuario);
        Task UpdateUsusario(Usuario pUsuario);
        Task DeleteUsusario(Usuario pUsuario);
    }
}
