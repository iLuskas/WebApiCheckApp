using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Core.Interfaces.Services;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Domain.Services.Services
{
    public class ServiceEquipamento_Seguranca : ServiceBase<Equipamento_Seguranca>, IServiceEquipamento_Seguranca
    {
        private readonly IRepositoryEquipamento_Seguranca _repositoryEquipamento_Seguranca;

        public ServiceEquipamento_Seguranca(IRepositoryEquipamento_Seguranca repositoryEquipamento_Seguranca) : base(repositoryEquipamento_Seguranca)
        {
            _repositoryEquipamento_Seguranca = repositoryEquipamento_Seguranca;
        }

        public IEnumerable<Equipamento_Seguranca> getAllEquipamento()
        {
            return _repositoryEquipamento_Seguranca.getAllEquipamento();
        }

        public IEnumerable<Equipamento_Seguranca> getAllEquipamentoByEmpresaId(int EmpresaId)
        {
            return _repositoryEquipamento_Seguranca.getAllEquipamentoByEmpresaId(EmpresaId);
        }

        public IEnumerable<Equipamento_Seguranca> getAllEquipamentoByEmpresaIdAndTipo(int EmpresaId, int tipoId)
        {
            return _repositoryEquipamento_Seguranca.getAllEquipamentoByEmpresaIdAndTipo(EmpresaId, tipoId);
        }

        public Equipamento_Seguranca getEquipamentoById(int id)
        {
            return _repositoryEquipamento_Seguranca.getEquipamentoById(id);
        }
    }
}
