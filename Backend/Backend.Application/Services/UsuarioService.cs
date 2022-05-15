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

        public Task DeleteUsuario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuarios()
        {
            IEnumerable<Usuario> mUsuarioList = await iUsuarioRepository.GetAllUsuarioWithTipousuario();

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

        public Task InsertUsuario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUsuario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
