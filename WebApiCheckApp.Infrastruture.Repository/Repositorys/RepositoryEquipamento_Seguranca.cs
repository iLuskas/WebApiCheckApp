using AcessoFacilSqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
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
        private IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositoryEquipamento_Seguranca(CheckappContext checkAppContext, IConfiguration configuration) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
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

        public dynamic getEquipByNumExtintor(string numExtintor, int empId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                            " +
                               "    B.RAZAOSOCIAL,                                                                                " +
                               "    C.ID,                                                                                         " +
                               "    C.LOCALIZACAO_EQUIPAMENTO,                                                                    " +
                               "    C.QRCODE,                                                                                     " +
                               "    C.QRCODE_DATA_GERACAO,                                                                        " +
                               "    C.DATACRIACAO_EQUIPAMENTO,                                                                    " +
                               "    D.NUM_EXT,                                                                                    " +
                               "    D.SELOINMETRO_EXT,                                                                            " +
                               "    D.FABRICANTE_EXT,                                                                             " +
                               "    D.TIPO_EXT,                                                                                   " +
                               "    D.CAPACIDADE_EXT,                                                                             " +
                               "    D.ANOFABRICACAO_EXT                                                                           " +
                               "FROM  EMPRESACLIENTE AS B(NOLOCK)                                                                 " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                        " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                        " +
                               "WHERE D.NUM_EXT = @NUMEXTINTOR AND B.ID = @EMPID                                                   ";

                query.AdicionarParametro("NUMEXTINTOR", numExtintor);
                query.AdicionarParametro("EMPID", empId);
                query.Abrir();

                while (query.Proximo())
                {
                    return new
                    {
                        Empresa = query.ObterString("RAZAOSOCIAL", true),
                        EquipamentoId = query.ObterInteiro("ID", 0),
                        Localizacao = query.ObterString("LOCALIZACAO_EQUIPAMENTO", true),
                        QrCode = query.ObterString("QRCODE", true),
                        DtQrCode = query.ObterDateTime("QRCODE_DATA_GERACAO", Convert.ToDateTime("01/01/1900")),
                        DtCricaoEquipamento = query.ObterDateTime("DATACRIACAO_EQUIPAMENTO"),
                        NumeroExtintor = query.ObterInteiro("NUM_EXT", 0),
                        SeloInmetroExtintor = query.ObterString("SELOINMETRO_EXT", true),
                        FabricanteExtintor = query.ObterString("FABRICANTE_EXT", true),
                        TipoExtintor = query.ObterString("TIPO_EXT", true),
                        CapacidadeExtintor = query.ObterInteiro("CAPACIDADE_EXT", 0),
                        AnoFabricadoExtintor = query.ObterString("ANOFABRICACAO_EXT", true),
                        UltManutencao = getManutEquipById(query.ObterInteiro("ID", 0))
                    };
                };

                return null;
            }
        }

        public dynamic getManutEquipById(int equipId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                              " +
                               "    TOP 1                                                                           " +
                               "    M.UltimoTeste,                                                                  " +
                               "	M.DataReteste,                                                                  " +
                               "	M.DataRecarga,                                                                  " +
                               "    M.DataProximaRecarga                                                            " +
                               "FROM Manutencao AS M(NOLOCK)                                                        " +
                               "INNER JOIN Equipamento_Seguranca AS ES(NOLOCK) ON M.EquipamentoSegurancaId = ES.Id  " +
                               "WHERE ES.ID = @EQUIPID                                                              " +
                               "ORDER BY M.AgendaInspManutId DESC                                                   ";

                query.AdicionarParametro("EQUIPID", equipId);
                query.Abrir();

                while (query.Proximo())
                {
                    return new
                    {
                        UltimoTeste = query.ObterString("UltimoTeste", true),
                        DataReteste = query.ObterString("DataReteste", true),
                        DataRecarga = query.ObterString("DataRecarga", true),
                        DataProximaRecarga = query.ObterString("DataProximaRecarga", true)
                    };
                };

                return null;
            }
        }

        public IEnumerable<dynamic> getRelatEquipamentos(DateTime dataIni, DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                             " +
                                "    A.ID as NUMEROAGENDA,                                                                          " +
                                "    B.RAZAOSOCIAL,                                                                                 " +
                                "    C.LOCALIZACAO_EQUIPAMENTO,                                                                     " +
                                "    D.NUM_EXT,                                                                                     " +
                                "    D.SELOINMETRO_EXT,                                                                             " +
                                "    D.FABRICANTE_EXT,                                                                              " +
                                "    D.TIPO_EXT,                                                                                    " +
                                "    D.CAPACIDADE_EXT,                                                                              " +
                                "    D.ANOFABRICACAO_EXT,                                                                           " +
                                "    F.NOME AS INSPETOR,                                                                             " +
                                "	 E.ULTIMAREC_INSP,                                                                              " +
                                "	 E.PROXIMOREC_INSP,                                                                             " +
                                "	 E.ULTIMORETESTE_INSP,                                                                          " +
                                "	 E.PROXIMORETESTE_INSP,                                                                         " +
                                "	 E.ESTADOCILINDRO_INSP,                                                                         " +
                                "	 E.ESTADOLOCAL_INSP,                                                                            " +
                                "	 E.SELOLACRE_INSP,                                                                              " +
                                "	 E.SINALIZACAOPISO_INSP,                                                                        " +
                                "	 E.SINALIZACAOACESSO_INSP,                                                                      " +
                                "	 E.OBS_INSP,                                                                                    " +
                                "	 E.DURACAO                                                                                      " +
                                "FROM EQUIPAMENTO_SEGURANCA AS C(NOLOCK)                                                            " +
                                "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON C.EMPRESACLIENTEID = B.ID                                " +
                                "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                         " +
                                "LEFT JOIN  AGENDAINSPMANUT AS A(NOLOCK) ON B.ID = A.EMPRESACLIENTEID                               " +
                                "LEFT JOIN INSPECAO AS E(NOLOCK) ON E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID  " +
                                "LEFT JOIN FUNCIONARIO AS F(NOLOCK) ON E.FUNCIONARIOID = F.ID AND F.ID = A.FUNCIONARIOID            " +
                                "WHERE A.DATAINICIAL BETWEEN @DATAINI AND @DATAFIM                                                  " +
                                "ORDER BY B.RAZAOSOCIAL ASC                                                                         ";

                query.AdicionarParametro("DATAINI", dataIni);
                query.AdicionarParametro("DATAFIM", dataFim);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();
                while (query.Proximo())
                {
                    lista.Add(new
                    {
                        NumeroAgenda = query.ObterInteiro("NUMEROAGENDA", 0),
                        Empresa = query.ObterString("RAZAOSOCIAL", true),
                        Localizacao = query.ObterString("LOCALIZACAO_EQUIPAMENTO", true),
                        Num_ext = query.ObterInteiro("NUM_EXT", 0),
                        SeloInmetro_ext = query.ObterString("SELOINMETRO_EXT", true),
                        Fabricante_ext = query.ObterString("FABRICANTE_EXT", true),
                        Tipo_ext = query.ObterString("TIPO_EXT", true),
                        Capacidade_ext = query.ObterInteiro("CAPACIDADE_EXT", 0),
                        AnoFabricacao_ext = query.ObterString("ANOFABRICACAO_EXT", true),
                        NomeInspetor = string.IsNullOrEmpty(query.ObterString("INSPETOR", true)) ? "NÃO INSPECIONADO" : query.ObterString("INSPETOR", true),
                        UltimoRecInsp = string.IsNullOrEmpty(query.ObterString("ULTIMAREC_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("ULTIMAREC_INSP", true),
                        ProximoRecInsp = string.IsNullOrEmpty(query.ObterString("PROXIMOREC_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("PROXIMOREC_INSP", true),
                        UltimoRetInsp = string.IsNullOrEmpty(query.ObterString("ULTIMORETESTE_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("ULTIMORETESTE_INSP", true),
                        ProximoRetInsp = string.IsNullOrEmpty(query.ObterString("PROXIMORETESTE_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("PROXIMORETESTE_INSP", true),
                        EstadoCilindroInsp = string.IsNullOrEmpty(query.ObterString("ESTADOCILINDRO_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("ESTADOCILINDRO_INSP", true),
                        EstadoLocalInsp = string.IsNullOrEmpty(query.ObterString("ESTADOLOCAL_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("ESTADOLOCAL_INSP", true),
                        SeloLacreInsp = string.IsNullOrEmpty(query.ObterString("SELOLACRE_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("SELOLACRE_INSP", true),
                        SinalizacaoPisoInsp = string.IsNullOrEmpty(query.ObterString("SINALIZACAOPISO_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("SINALIZACAOPISO_INSP", true),
                        SinalizacaoAcessoInsp = string.IsNullOrEmpty(query.ObterString("SINALIZACAOACESSO_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("SINALIZACAOACESSO_INSP", true),
                        Duracao = string.IsNullOrEmpty(query.ObterString("DURACAO", true)) ? "NÃO INSPECIONADO" : query.ObterString("DURACAO", true),
                        ObsInsp = string.IsNullOrEmpty(query.ObterString("OBS_INSP", true)) ? "NÃO INSPECIONADO" : query.ObterString("OBS_INSP", true)
                    });
                };

                return lista ?? null;
            }
        }
        public IEnumerable<dynamic> getRelatEquipInsp()
        {
           using (Query query = new Query(_stringConexao))
           {
               query.Script = "SELECT                                                                                                " +
                               "    EC.RazaoSocial AS EMPRESA,                                                                       " +
                               "    SUM(CASE WHEN(MONTH(I.DataFinal) = 1) THEN 1 ELSE 0 END) Jan,                                    " +
                               "    SUM(CASE WHEN(MONTH(I.DataFinal) = 2) THEN 1 ELSE 0 END) Fev,                                    " +
                               "    SUM(CASE WHEN(MONTH(I.DataFinal) = 3) THEN 1 ELSE 0 END) Mar,                                    " +
                               "	 SUM(CASE WHEN(MONTH(I.DataFinal) = 4) THEN 1 ELSE 0 END) Abr,                                    " +
                               "    SUM(CASE WHEN(MONTH(I.DataFinal) = 5) THEN 1 ELSE 0 END) Mai,                                    " +
                               "    SUM(CASE WHEN(MONTH(I.DataFinal) = 6) THEN 1 ELSE 0 END) Jun,                                    " +
                               "	 SUM(CASE WHEN(MONTH(I.DataFinal) = 7) THEN 1 ELSE 0 END) Jul,                                    " +
                               "    SUM(CASE WHEN(MONTH(I.DataFinal) = 8) THEN 1 ELSE 0 END) Ago,                                    " +
                               "    SUM(CASE WHEN(MONTH(I.DataFinal) = 9) THEN 1 ELSE 0 END) as 'Set',                               " +
                               "	 SUM(CASE WHEN(MONTH(I.DataFinal) = 10) THEN 1 ELSE 0 END) as  'Out',                             " +
                               "	 SUM(CASE WHEN(MONTH(I.DataFinal) = 11) THEN 1 ELSE 0 END) Nov,                                   " +
                               "	 SUM(CASE WHEN(MONTH(I.DataFinal) = 12) THEN 1 ELSE 0 END) Dez                                    " +
                               "FROM                                                                                                 " +
                               "    AGENDAINSPMANUT AS AIM(NOLOCK)                                                                   " +
                               "    INNER JOIN FUNCIONARIO AS F(NOLOCK) ON AIM.FUNCIONARIOID = F.ID                                  " +
                               "    INNER JOIN EMPRESACLIENTE AS EC(NOLOCK) ON EC.ID = AIM.EMPRESACLIENTEID                          " +
                               "    INNER JOIN Equipamento_Seguranca AS ES(NOLOCK) ON ES.EmpresaClienteId = EC.Id                    " +
                               "    INNER JOIN Inspecao AS I(NOLOCK) ON( EC.ID = I.EMPRESACLIENTEID                                  " +
                               "                                        AND AIM.ID = I.AGENDAINSPMANUTID                             " +
                               "                                        AND ES.ID = I.EquipamentoSegurancaId)                        " +
                               "WHERE                                                                                                " +
                               "    AIM.TIPOAGENDAMENTOID = 1                                                                        " +
                               "GROUP BY                                                                                             " +
                               "    EC.RazaoSocial                                                                                   ";

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

        public IEnumerable<dynamic> getRelatEquipNotInsp()
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script =  "SELECT                                                                              " +
                                "    EC.RazaoSocial AS EMPRESA,                                                      " +
                                "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 1) THEN 1 ELSE 0 END) Jan,               " +
                                "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 2) THEN 1 ELSE 0 END) Fev,               " +
                                "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 3) THEN 1 ELSE 0 END) Mar,               " +
                                "	 SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 4) THEN 1 ELSE 0 END) Abr,               " +
                                "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 5) THEN 1 ELSE 0 END) Mai,               " +
                                "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 6) THEN 1 ELSE 0 END) Jun,               " +
                                "	 SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 7) THEN 1 ELSE 0 END) Jul,               " +
                                "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 8) THEN 1 ELSE 0 END) Ago,               " +
                                "    SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 9) THEN 1 ELSE 0 END) as 'Set',          " +
                                "	 SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 10) THEN 1 ELSE 0 END) as  'Out',        " +
                                "	 SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 11) THEN 1 ELSE 0 END) Nov,              " +
                                "	 SUM(CASE WHEN(MONTH(AIM.DATAINICIAL) = 12) THEN 1 ELSE 0 END) Dez               " +
                                "FROM                                                                                " +
                                "    AGENDAINSPMANUT AS AIM(NOLOCK)                                                  " +
                                "    INNER JOIN FUNCIONARIO AS F(NOLOCK) ON AIM.FUNCIONARIOID = F.ID                 " +
                                "    INNER JOIN EMPRESACLIENTE AS EC(NOLOCK) ON EC.ID = AIM.EMPRESACLIENTEID         " +
                                "    INNER JOIN Equipamento_Seguranca AS ES(NOLOCK) ON ES.EmpresaClienteId = EC.Id   " +
                                "    LEFT JOIN INSPECAO AS I(NOLOCK) ON(EC.ID = I.EMPRESACLIENTEID                   " +
                                "                                        AND AIM.ID = I.AGENDAINSPMANUTID            " +
                                "                                        AND ES.ID = I.EquipamentoSegurancaId)       " +
                                "WHERE                                                                               " +
                                "    AIM.TIPOAGENDAMENTOID = 1 AND I.ID IS NULL                                      " +
                                "GROUP BY                                                                            " +
                                "    EC.RazaoSocial                                                                  ";

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