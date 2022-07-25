using AutoMapper;
using Backend.Application.Interfaces;
using Backend.Application.Usuarios.DTOs;
using Backend.Core.Entities;
using Backend.Core.Repositories;

namespace Backend.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        #region Propiedades
        private readonly IMapper iMapper;
        private readonly IUsuarioRepository iUsuarioRepository;
        private readonly ITipousuarioRepository iTipoUsuarioRepository;
        #endregion

        public UsuarioService(IMapper pMapper, IUsuarioRepository pUsuarioRepository, ITipousuarioRepository pTipoUsuarioRepository)
        {
            iMapper = pMapper;
            iUsuarioRepository = pUsuarioRepository;
            iTipoUsuarioRepository = pTipoUsuarioRepository;
        }

        #region Usuario
        public async Task<UsuarioDTO?> DeleteUsuario(string pNombreusuario)
        {
            Usuario? mUsuario = await iUsuarioRepository.GetUsuarioByNombreUsuario(pNombreusuario);

            if (mUsuario != null)
            {
                await iUsuarioRepository.DeleteAsync(mUsuario!);

                return iMapper.Map<UsuarioDTO>(mUsuario);
            }

            return null;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetUsuarios()
        {
            IEnumerable<Usuario> mUsuarioList = await iUsuarioRepository.GetAllAsync();

            return iMapper.Map<IEnumerable<UsuarioDTO>>(mUsuarioList);
        }

        public async Task<IEnumerable<UsuarioExtendedDTO>> GetUsuariosExtended()
        {
            IEnumerable<Usuario> mUsuarioList = await iUsuarioRepository.GetAllUsuarioExtended();

            return iMapper.Map<IEnumerable<UsuarioExtendedDTO>>(mUsuarioList);
        }

        public async Task<UsuarioDTO> InsertUsuario(UsuarioDTO pUsuario)
        {
            Usuario mUsuario = await iUsuarioRepository.AddAsync(iMapper.Map<Usuario>(pUsuario));

            return iMapper.Map<UsuarioDTO>(mUsuario);
        }

        public async Task<UsuarioDTO> UpdateUsuario(UsuarioDTO pUsuario)
        {
            Usuario mUsuario = await iUsuarioRepository.UpdateAsync(iMapper.Map<Usuario>(pUsuario));

            return iMapper.Map<UsuarioDTO>(mUsuario);
        }
        #endregion

        #region TipoUsuario
        public async Task<IEnumerable<TipoUsuarioDTO>> GetTipoUsuario()
        {
            var mTipoUsuarioList = await iTipoUsuarioRepository.GetAllAsync();

            return iMapper.Map<IEnumerable<TipoUsuarioDTO>>(mTipoUsuarioList);
        }
        #endregion
    }
}
