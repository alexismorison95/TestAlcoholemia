using AutoMapper;
using Backend.Application.DTOs.Usuarios;
using Backend.Application.Interfaces;
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
                Usuario mDeletedUsuario = await iUsuarioRepository.DeleteAsync(mUsuario!);

                return iMapper.Map<UsuarioDTO>(mDeletedUsuario);
            }

            return null;
        }

        public async Task<IEnumerable<UsuarioTipoUsuarioDTO>> GetUsuarios()
        {
            IEnumerable<Usuario> mUsuarioList = await iUsuarioRepository.GetAllUsuarioWithTipousuario();

            return iMapper.Map<IEnumerable<UsuarioTipoUsuarioDTO>>(mUsuarioList);
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

        public async Task<TipoUsuarioDTO> InsertTipoUsuario(TipoUsuarioDTO pTipoUsuario)
        {
            Tipousuario mTipoUsuario = await iTipoUsuarioRepository.AddAsync(iMapper.Map<Tipousuario>(pTipoUsuario));

            return iMapper.Map<TipoUsuarioDTO>(mTipoUsuario);
        }

        public async Task<TipoUsuarioDTO?> DeleteTipoUsuario(int pId)
        {
            Tipousuario? mTipoUsuario = await iTipoUsuarioRepository.GetByIdAsync(pId);

            if (mTipoUsuario != null)
            {
                await iTipoUsuarioRepository.DeleteAsync(mTipoUsuario);

                return iMapper.Map<TipoUsuarioDTO>(mTipoUsuario);
            }

            return null;
        }
        #endregion
    }
}
