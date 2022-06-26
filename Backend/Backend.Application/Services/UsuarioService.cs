using AutoMapper;
using Backend.Application.DTOs.Usuarios;
using Backend.Application.Interfaces;
using Backend.Core.Entities;
using Backend.Core.Repositories;

namespace Backend.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper iMapper;
        private readonly IUsuarioRepository iUsuarioRepository;

        public UsuarioService(IMapper pMapper, IUsuarioRepository pUsuarioRepository)
        {
            iMapper = pMapper;
            iUsuarioRepository = pUsuarioRepository;
        }

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
    }
}
