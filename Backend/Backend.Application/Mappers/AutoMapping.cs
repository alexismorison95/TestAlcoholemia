﻿using AutoMapper;
using Backend.Application.Equipos.DTOs;
using Backend.Application.Usuarios.DTOs;
using Backend.Core.Entities;

namespace Backend.Application.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioExtendedDTO>()
                .ForMember(dest => dest.Tipousuario, opt => opt.MapFrom(src => src.Tipousuario!.Tipo));
            CreateMap<Tipousuario, TipoUsuarioDTO>().ReverseMap();
            CreateMap<Equipo, EquipoDTO>().ReverseMap();
            CreateMap<Equipo, EquipoExtendedDTO>().ReverseMap();
        }
    }
}
