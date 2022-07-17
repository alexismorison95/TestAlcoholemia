using AutoMapper;
using Backend.Application.DTOs.Login;
using Backend.Application.DTOs.Usuarios;
using Backend.Application.Interfaces;
using Backend.Core.Entities;
using Backend.Core.Repositories;

namespace Backend.Application.Services
{
    public class LoginService : ILoginService
    {
        #region Propiedades
        private readonly IMapper iMapper;
        private readonly IUsuarioRepository iUsuarioRepository;
        private readonly ITipousuarioRepository iTipoUsuarioRepository;
        #endregion

        public LoginService(IMapper pMapper, IUsuarioRepository pUsuarioRepository, ITipousuarioRepository pTipoUsuarioRepository)
        {
            iMapper = pMapper;
            iUsuarioRepository = pUsuarioRepository;
            iTipoUsuarioRepository = pTipoUsuarioRepository;
        }

        public async Task<Usuario?> UserExists(LoginDTO pLoginDTO)
        {
            IEnumerable<Usuario> mList = await iUsuarioRepository.GetAllUsuarioWithTipousuario();

            Usuario? mUsuario = mList.Where(x => x.Nombreusuario == pLoginDTO.UserName && x.Contrasenia == pLoginDTO.Password).FirstOrDefault();

            if (mUsuario == null)
            {
                return null;
            }

            return mUsuario;
        }
    }
}
