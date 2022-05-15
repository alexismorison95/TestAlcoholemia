using AutoMapper;
using Backend.Application.DTOs.Usuarios;
using Backend.Core.Entities;

namespace Backend.Application.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, GetUsuarioDTO>()
                .ForMember(dest => dest.Tipousuario, opt => opt.MapFrom(src => src.Tipousuario.Tipo));
        }
    }
}
