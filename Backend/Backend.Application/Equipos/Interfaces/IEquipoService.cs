using Backend.Application.Equipos.DTOs;

namespace Backend.Application.Equipos.Interfaces
{
    public interface IEquipoService
    {
        Task<IEnumerable<EquipoDTO>> GetEquipos();
        Task<EquipoDTO> UpdateEquipo(EquipoDTO pEquipoDTO);
        Task<EquipoDTO> InsertEquipo(EquipoDTO pEquipoDTO);
        Task<EquipoDTO?> DeleteEquipo(int pId);
    }
}
