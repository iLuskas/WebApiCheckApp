using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Util;
using webApiCheckApp.Application.DTO.DTO;
using webApiCheckApp.Application.DTO.DTO.DTOHelpers;
using WebApiCheckApp.Domain.Models;
using WebApiCheckApp.Domain.Models.Helpers;

namespace WebApiCheckApp.Infrastruture.CrossCutting.Adapter
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.perfil, opt => opt.MapFrom(src => src.Funcionario.Perfil.Funcao_perfil))
                .AfterMap((src, dest) => dest.Senha = string.Empty);
            CreateMap<UsuarioDTO, Usuario>()
                .AfterMap((src, dest) => dest.Senha = Utilidades.GerarHashMd5(src.Senha));
                

            CreateMap<EmpresaCliente, EmpresaClienteDTO>()
                .ForMember(dest => dest.enderecoDTOs, opt => opt.MapFrom(src => src.Enderecos))
                .ForMember(dest => dest.telefoneDTOs, opt => opt.MapFrom(src => src.Telefones))
                .ForMember(dest => dest.EquipamentosDTOs, opt => opt.MapFrom(src => src.Equipamentos)).ReverseMap();

            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Telefone, TelefoneDTO>().ReverseMap();
            CreateMap<Perfil, PerfilDTO>().ReverseMap();

            CreateMap<Funcionario, FuncionarioDTO>()
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.PerfilId, opt => opt.MapFrom(src => src.PerfilId))
                .ForMember(dest => dest.enderecoDTOs, opt => opt.MapFrom(src => src.Enderecos))
                .ForMember(dest => dest.telefoneDTOs, opt => opt.MapFrom(src => src.Telefones)).ReverseMap();

            CreateMap<Equipamento_Seguranca, Equipamento_SegurancaDTO>()
            .ForMember(dest => dest.ExtintorDTO, opt => opt.MapFrom(src => src.Extintor)).ReverseMap();

            CreateMap<Tipo_equipamento, Tipo_EquipamentoDTO>().ReverseMap();

            CreateMap<Extintor, ExtintorDTO>().ReverseMap();

            CreateMap<ModeloAlterarSenhaUser, ModeloAlterarSenhaUserDTO>().ReverseMap();

            CreateMap<Inspecao, InspecaoDTO>()
                 .ForMember(dest => dest.EquipamentoSegurancaDTO, opt => opt.MapFrom(src => src.EquipamentoSeguranca)).ReverseMap();

            CreateMap<Manutencao, ManutencaoDTO>()
                 .ForMember(dest => dest.EquipamentoSegurancaDTO, opt => opt.MapFrom(src => src.EquipamentoSeguranca)).ReverseMap();

            CreateMap<AgendaInspManut, AgendaInspManutDTO>()
                .ForMember(dest => dest.NomeFuncionario, opt => opt.MapFrom(src => src.Funcionario.Nome))
                .ForMember(dest => dest.Empresa, opt => opt.MapFrom(src => src.EmpresaCliente.RazaoSocial))
                .ForMember(dest => dest.TipoEquipamento, opt => opt.MapFrom(src => src.TipoEquipamento.Tipo))
                .ForMember(dest => dest.TipoAgendamento, opt => opt.MapFrom(src => src.TipoAgendamento.TipoAgenda))
                .ForMember(dest => dest.StatusInspManut, opt => opt.MapFrom(src => src.StatusInspManut.statusAgenda))
                .ForMember(dest => dest.InspecaoDTOs, opt => opt.MapFrom(src => src.Inspecoes));

        }
    }
}
