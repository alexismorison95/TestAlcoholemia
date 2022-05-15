﻿using AutoMapper;
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

        public Task DeleteUsuario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetUsuarioDTO>> GetUsuarios()
        {
            IEnumerable<Usuario> mUsuarioList = await iUsuarioRepository.GetAllUsuarioWithTipousuario();

            return iMapper.Map<IEnumerable<GetUsuarioDTO>>(mUsuarioList);
        }

        public async Task<Usuario> InsertUsuario(UsuarioDTO pUsuario)
        {
            Usuario mUsuario = await iUsuarioRepository.AddAsync(iMapper.Map<Usuario>(pUsuario));

            return mUsuario;
        }

        public Task UpdateUsuario(Usuario pUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
