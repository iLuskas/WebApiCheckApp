using AcessoFacilSqlServer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;
using WebApiCheckApp.Infrastruture.Repository.Repositorys;

namespace WebApiCheckApp.Infrastructure.Repository.Repositorys
{
    public class RepositoryManutencao : RepositoryBase<Manutencao>, IRepositoryManutencao
    {
        private readonly CheckappContext _checkappContext;
        private IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositoryManutencao(CheckappContext checkappContext, IConfiguration configuration) : base(checkappContext)
        {
            _checkappContext = checkappContext;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }

        public Manutencao GetManutencaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = " SELECT " +
                                "	M.* " +
                                "FROM " +
                                "	MANUTENCAO AS M(NOLOCK)" +
                                "WHERE " +
                                "	AGENDAINSPMANUTID = @AGEID AND EQUIPAMENTOSEGURANCAID = @EQUIPID";

                query.AdicionarParametro("EQUIPID", equipamentoId);
                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                while (query.Proximo())
                    return new Manutencao
                    {
                        Id = query.ObterInteiro("Id", 0),
                        StatusInspManutId = query.ObterInteiro("StatusInspManutId", 0),
                        FuncionarioId = query.ObterInteiro("FuncionarioId", 0),
                        EmpresaClienteId = query.ObterInteiro("EmpresaClienteId", 0),
                        AgendaInspManutId = query.ObterInteiro("AgendaInspManutId", 0),
                        AnoFabricacao = query.ObterString("AnoFabricacao", true),
                        Capacidade = query.ObterString("Capacidade", true),
                        FabricanteExt = query.ObterString("FabricanteExt", true),
                        NumCilindro = query.ObterString("NumCilindro", true),
                        Aprovado = query.ObterBool("Aprovado"),
                        Reprovado = query.ObterBool("Reprovado"),
                        DataReteste = query.ObterString("DataReteste", true),
                        SeloInmetro = query.ObterString("SeloInmetro", true),
                        DataRecarga = query.ObterString("DataRecarga", true),
                        DataProximaRecarga = query.ObterString("DataRecarga", true),
                        TipoExt = query.ObterString("TipoExt", true),
                        UltimoTeste = query.ObterString("UltimoTeste", true),
                        ObsManut = query.ObterString("ObsManut", true),
                        DataInicial = query.ObterDateTime("DataInicial", Convert.ToDateTime("01/01/1900 00:00:00")),
                        DataFinal = query.ObterDateTime("DataFinal", Convert.ToDateTime("01/01/1900 00:00:00")),
                        Duracao = query.ObterString("Duracao", true),
                        EquipamentoSegurancaId = query.ObterInteiro("EquipamentoSegurancaId", 0)
                    };

                return null;
            }
        }
    }
}
