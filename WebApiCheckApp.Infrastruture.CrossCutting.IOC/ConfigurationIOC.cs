using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Application.Services;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Services.Services;
using WebApiCheckApp.Infrastruture.Repository.Repositorys;

namespace WebApiCheckApp.Infrastruture.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceUsuario>().As<IApplicationServiceUsuario>();
            builder.RegisterType<ApplicationServiceEmpresaCliente>().As<IApplicationServiceEmpresaCliente>();
            builder.RegisterType<ApplicationServiceEndereco>().As<IApplicationServiceEndereco>();
            builder.RegisterType<ApplicationServiceTelefone>().As<IApplicationServiceTelefone>();
            builder.RegisterType<ApplicationServicePerfil>().As<IApplicationServicePerfil>();
            builder.RegisterType<ApplicationServiceFuncionario>().As<IApplicationServiceFuncionario>();
            builder.RegisterType<ApplicationServiceTipo_Equipamento>().As<IApplicationServiceTipo_Equipamento>();
            builder.RegisterType<ApplicationServiceExtintor>().As<IApplicationServiceExtintor>();
            builder.RegisterType<ApplicationServiceEquipamento_Seguranca>().As<IApplicationServiceEquipamento_Seguranca>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceUsuario>().As<IServiceUsuario>();
            builder.RegisterType<ServiceEmpresaCliente>().As<IServiceEmpresaCliente>();
            builder.RegisterType<ServiceEndereco>().As<IServiceEndereco>();
            builder.RegisterType<ServiceTelefone>().As<IServiceTelefone>();
            builder.RegisterType<ServicePerfil>().As<IServicePerfil>();
            builder.RegisterType<ServiceFuncionario>().As<IServiceFuncionario>();
            builder.RegisterType<ServiceTipo_Equipamento>().As<IServiceTipo_Equipamento>();
            builder.RegisterType<ServiceEquipamento_Seguranca>().As<IServiceEquipamento_Seguranca>();
            builder.RegisterType<ServiceExtintor>().As<IServiceExtintor>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryUsuario>().As<IRepositoryUsuario>();
            builder.RegisterType<RepositoryEmpresaCliente>().As<IRepositoryEmpresaCliente>();
            builder.RegisterType<RepositoryEndereco>().As<IRepositoryEndereco>();
            builder.RegisterType<RepositoryTelefone>().As<IRepositoryTelefone>();
            builder.RegisterType<RepositoryPerfil>().As<IRepositoryPerfil>();
            builder.RegisterType<RepositoryFuncionario>().As<IRepositoryFuncionario>();
            builder.RegisterType<RepositoryTipo_equipamento>().As<IRepositoryTipo_Equipamento>();
            builder.RegisterType<RepositoryEquipamento_Seguranca>().As<IRepositoryEquipamento_Seguranca>();
            builder.RegisterType<RepositoryExtintor>().As<IRepositoryExtintor>();
            #endregion

            #endregion

        }
    }
}
