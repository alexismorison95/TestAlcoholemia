using Backend.Application.DTOs.Usuarios;
using Backend.Application.Interfaces;
using Backend.Core.Entities;
using Backend.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository iUsuarioRepository;

        public UsuarioService(IUsuarioRepository pUsuarioRepository)
        {
            iUsuarioRepository = pUsuarioRepository;
        }

        public Task DeleteUsusario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsers()
        {
            IEnumerable<Usuario> mUsuarioList = await iUsuarioRepository.GetAllAsync();

            IEnumerable<UsuarioDTO> mResult = mUsuarioList.Select(x => new UsuarioDTO
            {
                Nombreusuario = x.Nombreusuario,
                Contrasenia = x.Contrasenia,   
                Activo = x.Activo,
                Nombrereal = x.Nombrereal,
                Tipousuario = x.Tipousuario.Tipo
            });

            return mResult;
        }

        public Task InsertUsusario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUsusario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
