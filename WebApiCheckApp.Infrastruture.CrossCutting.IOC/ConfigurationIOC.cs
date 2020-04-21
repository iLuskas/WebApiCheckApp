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
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceUsuario>().As<IServiceUsuario>();
            builder.RegisterType<ServiceEmpresaCliente>().As<IServiceEmpresaCliente>();
            builder.RegisterType<ServiceEndereco>().As<IServiceEndereco>();
            builder.RegisterType<ServiceTelefone>().As<IServiceTelefone>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryUsuario>().As<IRepositoryUsuario>();
            builder.RegisterType<RepositoryEmpresaCliente>().As<IRepositoryEmpresaCliente>();
            builder.RegisterType<RepositoryEndereco>().As<IRepositoryEndereco>();
            builder.RegisterType<RepositoryTelefone>().As<IRepositoryTelefone>();
            #endregion

            #endregion

        }
    }
}
