using AutoMapper;
using Backend.Application.Equipos.DTOs;
using Backend.Application.Equipos.Interfaces;
using Backend.Core.Entities;
using Backend.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Equipos.Services
{
    public class EquipoService : IEquipoService
    {
        #region Propiedades
        private readonly IMapper iMapper;
        private readonly IEquipoRepository iEquipoRepository;
        #endregion

        public EquipoService(IMapper pMapper, IEquipoRepository pEquipoRepository)
        {
            iMapper = pMapper;
            iEquipoRepository = pEquipoRepository;
        }

        public async Task<EquipoDTO?> DeleteEquipo(int pId)
        {
            Equipo? mEquipo = await iEquipoRepository.GetByIdAsync(pId);

            if (mEquipo != null)
            {
                await iEquipoRepository.DeleteAsync(mEquipo);

                return iMapper.Map<EquipoDTO>(mEquipo);
            }

            return null;
        }

        public async Task<IEnumerable<EquipoDTO>> GetEquipos()
        {
            IEnumerable<Equipo> mEquipoList = await iEquipoRepository.GetAllAsync();

            return iMapper.Map<IEnumerable<EquipoDTO>>(mEquipoList);
        }

        public async Task<EquipoDTO> InsertEquipo(EquipoDTO pEquipoDTO)
        {
            Equipo mEquipo = await iEquipoRepository.AddAsync(iMapper.Map<Equipo>(pEquipoDTO));

            return iMapper.Map<EquipoDTO>(mEquipo);
        }

        public async Task<EquipoDTO> UpdateEquipo(EquipoDTO pEquipoDTO)
        {
            Equipo mEquipo = await iEquipoRepository.UpdateAsync(iMapper.Map<Equipo>(pEquipoDTO));

            return iMapper.Map<EquipoDTO>(mEquipo);
        }
    }
}
