using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryEquipamento_Seguranca : RepositoryBase<Equipamento_Seguranca>, IRepositoryEquipamento_Seguranca
    {
        private readonly CheckappContext _checkAppContext;

        public RepositoryEquipamento_Seguranca(CheckappContext checkAppContext) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
        }

        public IEnumerable<Equipamento_Seguranca> getAllEquipamento()
        {
            IQueryable<Equipamento_Seguranca> query = _checkAppContext.Equipamento_Segurancas
                .Include(eq => eq.Extintor);

            return query.AsNoTracking().OrderBy(eq => eq.Id).ToList();
        }

        public IEnumerable<Equipamento_Seguranca> getAllEquipamentoByEmpresaId(int EmpresaId)
        {
            IQueryable<Equipamento_Seguranca> query = _checkAppContext.Equipamento_Segurancas
                .Include(eq => eq.Extintor);

            return query.AsNoTracking().Where(eq => eq.EmpresaClienteId == EmpresaId)
                .OrderBy(eq => eq.Id).ToList();
        }

        public IEnumerable<Equipamento_Seguranca> getAllEquipamentoByEmpresaIdAndTipo(int EmpresaId, int tipoId)
        {
            IQueryable<Equipamento_Seguranca> query = _checkAppContext.Equipamento_Segurancas
                .Include(eq => eq.Extintor);

            return query.AsNoTracking().Where(eq => eq.EmpresaClienteId == EmpresaId && eq.Tipo_equipamentoId == tipoId)
                .OrderBy(eq => eq.Id).ToList();
        }

        public Equipamento_Seguranca getEquipamentoById(int id)
        {
            IQueryable<Equipamento_Seguranca> query = _checkAppContext.Equipamento_Segurancas
                .Include(eq => eq.Extintor);

            return query.AsNoTracking().Where(eq => eq.Id == id).FirstOrDefault();
        }
    }
}