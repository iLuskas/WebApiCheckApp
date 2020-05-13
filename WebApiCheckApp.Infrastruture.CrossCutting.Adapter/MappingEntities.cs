﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.CrossCutting.Adapter
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<Usuario, UsuarioDTO>().AfterMap((src, dest) => dest.Senha = string.Empty);
            CreateMap<UsuarioDTO, Usuario>();

            CreateMap<EmpresaCliente, EmpresaClienteDTO>()
                .ForMember(dest => dest.enderecoDTOs, opt => opt.MapFrom(src => src.Enderecos))
                .ForMember(dest => dest.telefoneDTOs, opt => opt.MapFrom(src => src.Telefones)).ReverseMap();

            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
            CreateMap<Perfil, PerfilDTO>().ReverseMap();

            CreateMap<Funcionario, FuncionarioDTO>()
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.PerfilId, opt => opt.MapFrom(src => src.PerfilId))
                .ForMember(dest => dest.enderecoDTOs, opt => opt.MapFrom(src => src.Enderecos))
                .ForMember(dest => dest.telefoneDTOs, opt => opt.MapFrom(src => src.Telefones)).ReverseMap();
        }
    }
}
