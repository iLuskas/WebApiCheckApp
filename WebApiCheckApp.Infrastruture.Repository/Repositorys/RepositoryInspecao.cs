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
    public class RepositoryInspecao : RepositoryBase<Inspecao>, IRepositoryInspecao
    {
        private readonly CheckappContext _checkAppContext;
        private IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositoryInspecao(CheckappContext checkAppContext, IConfiguration configuration) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }

        public Inspecao GetInspecaoByEquipIdAndAgeId(int equipamentoId, int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = " SELECT " +
                                "	I.* " +
                                "FROM " +
                                "	INSPECAO AS I(NOLOCK)" +
                                "WHERE " +
                                "	AGENDAINSPMANUTID = @AGEID AND EQUIPAMENTOSEGURANCAID = @EQUIPID";

                query.AdicionarParametro("EQUIPID", equipamentoId);
                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                while (query.Proximo())
                    return new Inspecao
                    {
                        Id = query.ObterInteiro("Id", 0),
                        StatusInspManutId = query.ObterInteiro("StatusInspManutId", 0),
                        FuncionarioId = query.ObterInteiro("FuncionarioId", 0),
                        EmpresaClienteId = query.ObterInteiro("EmpresaClienteId", 0),
                        AgendaInspManutId = query.ObterInteiro("AgendaInspManutId", 0),
                        UltimaRec_Insp = query.ObterString("UltimaRec_Insp", true),
                        ProximoRec_Insp = query.ObterString("ProximoRec_Insp", true),
                        UltimoReteste_Insp = query.ObterString("UltimoReteste_Insp", true),
                        ProximoReteste_Insp = query.ObterString("ProximoReteste_Insp", true),
                        EstadoCilindro_Insp = query.ObterString("EstadoCilindro_Insp", true),
                        EstadoLocal_Insp = query.ObterString("EstadoLocal_Insp", true),
                        SeloLacre_insp = query.ObterString("SeloLacre_insp", true),
                        SinalizacaoPiso_insp = query.ObterString("SinalizacaoPiso_insp", true),
                        SinalizacaoAcesso_insp = query.ObterString("SinalizacaoAcesso_insp", true),
                        Obs_Insp = query.ObterString("Obs_Insp", true),
                        DataInicial = query.ObterDateTime("DataInicial", Convert.ToDateTime("01/01/1900 00:00:00")),
                        DataFinal = query.ObterDateTime("DataFinal", Convert.ToDateTime("01/01/1900 00:00:00")),
                        Duracao = query.ObterString("Duracao", true),
                        PrecisaManutencao = query.ObterBool("precisaManutencao"),
                        ImagemOcorrencia = query.ObterString("ImagemOcorrencia", true),
                        EquipamentoSegurancaId = query.ObterInteiro("EquipamentoSegurancaId", 0)
                    };

                return null;
            }
        }
    }
}
