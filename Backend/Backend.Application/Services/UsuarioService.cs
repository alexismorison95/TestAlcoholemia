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

        public async Task<IEnumerable<GetUsuarioDTO>> GetUsuarios()
        {
            IEnumerable<Usuario> mUsuarioList = await iUsuarioRepository.GetAllUsuarioWithTipousuario();

            IEnumerable<GetUsuarioDTO> mResult = mUsuarioList.Select(x => new GetUsuarioDTO
            {
                Nombreusuario = x.Nombreusuario,
                Contrasenia = x.Contrasenia,   
                Activo = x.Activo,
                Nombrereal = x.Nombrereal,
                Tipousuario = x.Tipousuario.Tipo
            });

            return mResult;
        }

        public async Task<Usuario> InsertUsuario(UsuarioDTO pUsuario)
        {
            Usuario mUsuario = await iUsuarioRepository.AddAsync(new Usuario
            {
                Nombreusuario = pUsuario.Nombreusuario,
                Contrasenia = pUsuario.Contrasenia,
                Activo=pUsuario.Activo,
                Nombrereal = pUsuario.Nombrereal,
                Tipousuarioid = pUsuario.Tipousuarioid
            });

            return mUsuario;
        }

        public Task UpdateUsuario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
