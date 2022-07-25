using AutoMapper;
using Backend.Application.Login.DTOs;
using Backend.Application.Login.Interfaces;
using Backend.Core.Entities;
using Backend.Core.Repositories;

namespace Backend.Application.Login.Services
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

        public Task<Usuario> GetLoginUser(string pUserName)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario?> UserExists(LoginDTO pLoginDTO)
        {
            IEnumerable<Usuario> mList = await iUsuarioRepository.GetAllUsuarioExtended();

            Usuario? mUsuario = mList.Where(x => x.Nombreusuario == pLoginDTO.UserName && x.Contrasenia == pLoginDTO.Password).FirstOrDefault();

            if (mUsuario == null)
            {
                return null;
            }

            return mUsuario;
        }
    }
}
