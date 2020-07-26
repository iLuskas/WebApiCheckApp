using AcessoFacilSqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Infrastruture.Repository.Repositorys
{
    public class RepositoryEmpresaCliente: RepositoryBase<EmpresaCliente>, IRepositoryEmpresaCliente
    {
        private readonly CheckappContext _checkAppContext;
        private readonly IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositoryEmpresaCliente(CheckappContext checkAppContext, IConfiguration configuration) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection"); ;
        }

        public EmpresaCliente getAllEquipamentoByIdAndTipo(int empresaId, int tipoId)
        {
            IQueryable<EmpresaCliente> query = _checkAppContext.EmpresaClientes
                .Include(e => e.Equipamentos)
                    .ThenInclude(eq => eq.Extintor);

            return query.AsNoTracking().Where(e => e.Equipamentos.Any(eq => eq.Tipo_equipamentoId == tipoId) && e.Id == empresaId).FirstOrDefault();
        }

        public IEnumerable<EmpresaCliente> getAllInfoEmpresaCliente()
        {
            IQueryable<EmpresaCliente> query = _checkAppContext.EmpresaClientes
           .Include(e => e.Enderecos)
           .Include(e => e.Telefones);

            return query.AsNoTracking().OrderBy(e => e.Id).ToList();            
        }

        public EmpresaCliente getAllInfoEmpresaClienteById(int id)
        {
            IQueryable<EmpresaCliente> query = _checkAppContext.EmpresaClientes
           .Include(e => e.Enderecos)
           .Include(e => e.Telefones);

            return query.AsNoTracking()
            .Where(e => e.Id == id).FirstOrDefault();  
        }

        public IEnumerable<dynamic> getRelatOcorrenciaForEmp()
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                          " +
                               "    EC.RAZAOSOCIAL AS EMPRESA,                                                  " +
                               "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 1) THEN 1 ELSE 0 END) JAN,           " +
                               "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 2) THEN 1 ELSE 0 END) FEV,           " +
                               "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 3) THEN 1 ELSE 0 END) MAR,           " +
                               "	SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 4) THEN 1 ELSE 0 END) ABR,           " +
                               "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 5) THEN 1 ELSE 0 END) MAI,           " +
                               "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 6) THEN 1 ELSE 0 END) JUN,           " +
                               "	SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 7) THEN 1 ELSE 0 END) JUL,           " +
                               "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 8) THEN 1 ELSE 0 END) AGO,           " +
                               "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 9) THEN 1 ELSE 0 END) 'SET',         " +
                               "	SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 10) THEN 1 ELSE 0 END) 'OUT',        " +
                               "	SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 11) THEN 1 ELSE 0 END) NOV,          " +
                               "	SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 12) THEN 1 ELSE 0 END) DEZ           " +
                               "FROM                                                                            " +
                               "    AGENDAINSPMANUT AS AIM(NOLOCK)                                              " +
                               "    INNER JOIN EMPRESACLIENTE AS EC(NOLOCK) ON EC.ID = AIM.EMPRESACLIENTEID     " +
                               "    INNER JOIN EQUIPAMENTO_SEGURANCA AS ES(NOLOCK) ON ES.EMPRESACLIENTEID = EC.ID" +
                               "    INNER JOIN MANUTENCAO AS I(NOLOCK) ON(EC.ID = I.EMPRESACLIENTEID            " +
                               "                                      AND AIM.ID = I.AGENDAINSPMANUTID          " +
                               "                                      AND ES.ID = I.EquipamentoSegurancaId)     " +
                               "WHERE                                                                           " +
                               "    AIM.TIPOAGENDAMENTOID = 2                                                   " +
                               "GROUP BY                                                                        " +
                               "    EC.RAZAOSOCIAL                                                              " +
                               "                                                                                ";
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();
                while (query.Proximo())
                {
                    lista.Add(new
                    {
                        Empresa = query.ObterString("EMPRESA", true),
                        Janeiro = query.ObterString("Jan", true),
                        Fevereiro = query.ObterString("Fev", true),
                        Marco = query.ObterString("Mar", true),
                        Abril = query.ObterString("Abr", true),
                        Maio = query.ObterString("Mai", true),
                        Junho = query.ObterString("Jun", true),
                        Julho = query.ObterString("Jul", true),
                        Agosto = query.ObterString("Ago", true),
                        Setembro = query.ObterString("Set", true),
                        Outubro = query.ObterString("Out", true),
                        Novembro = query.ObterString("Nov", true),
                        Dezembro = query.ObterString("Dez", true)
                    });
                };

                return lista ?? null;
            }
        }
    }
}
