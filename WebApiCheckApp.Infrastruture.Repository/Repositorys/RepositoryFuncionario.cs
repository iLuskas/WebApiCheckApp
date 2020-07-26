using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryFuncionario : RepositoryBase<Funcionario>, IRepositoryFuncionario
    {
        private readonly CheckappContext _checkAppContext;

        public RepositoryFuncionario(CheckappContext checkAppContext): base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
        }

        public IEnumerable<Funcionario> getAllInfoFuncionario()
        {
            IQueryable<Funcionario> query = _checkAppContext.Funcionarios
                .Include(e => e.Enderecos)
                .Include(e => e.Telefones);

            return query.AsNoTracking().OrderBy(e => e.Id).ToList();
        }

        public Funcionario getAllInfoFuncionarioById(int id)
        {
            IQueryable<Funcionario> query = _checkAppContext.Funcionarios
                .Include(e => e.Enderecos)
                .Include(e => e.Telefones);

            return query.AsNoTracking()
            .Where(e => e.Id == id).FirstOrDefault();
        }

        public int getFuncionarioByUsername(string userName)
        {
            IQueryable<Funcionario> query = _checkAppContext.Funcionarios
               .Include(u => u.Usuario);

            return query.AsNoTracking()
            .Where(e => e.Usuario.Login.ToLower() == userName.ToLower()).FirstOrDefault().Id;
        }

        public Funcionario getFuncionarioByName(string name)
        {
            IQueryable<Funcionario> query = _checkAppContext.Funcionarios
               .Include(u => u.Usuario);

            return query.AsNoTracking()
            .Where(e => e.Nome.ToLower() == name.ToLower()).FirstOrDefault();
        }
    }
}
