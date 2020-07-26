using AcessoFacilSqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Linq;
using Util;
using WebApiCheckApp.Data;
using WebApiCheckApp.Domain.Core.Interfaces.Repositorys;
using WebApiCheckApp.Domain.Models;
using WebApiCheckApp.Infrastruture.Repository.Repositorys;

namespace WebApiCheckApp.Infrastructure.Repository.Repositorys
{
    public class RepositoryAgendaInspManut : RepositoryBase<AgendaInspManut>, IRepositoryAgendaInspManut
    {
        private readonly CheckappContext _checkAppContext;
        private IConfiguration _configuration;
        private readonly string _stringConexao;

        public RepositoryAgendaInspManut(CheckappContext checkAppContext, IConfiguration configuration) : base(checkAppContext)
        {
            _checkAppContext = checkAppContext;
            _configuration = configuration;
            _stringConexao = _configuration.GetConnectionString("DefaultConnection");
        }

        public AgendaInspManut getAgendamentoById(int id)
        {
            IQueryable<AgendaInspManut> query = _checkAppContext.AgendaInspManuts
                .Include(a => a.Funcionario)
                .Include(a => a.EmpresaCliente)
                .Include(a => a.TipoEquipamento)
                .Include(a => a.TipoAgendamento)
                .Include(a => a.StatusInspManut);

            return query.AsNoTracking().Where(e => e.Id == id).FirstOrDefault();
        }

        public IEnumerable<AgendaInspManut> getAllAgendamento()
        {
            IQueryable<AgendaInspManut> query = _checkAppContext.AgendaInspManuts
             .Include(a => a.Funcionario)
             .Include(a => a.EmpresaCliente)
             .Include(a => a.TipoEquipamento)
             .Include(a => a.TipoAgendamento)
             .Include(a => a.StatusInspManut)
             .Include(a => a.Inspecoes).ThenInclude(i => i.EquipamentoSeguranca).ThenInclude(ES => ES.Extintor);

            return query.AsNoTracking().OrderBy(e => e.Id).ToList();
        }

        public IEnumerable<AgendaInspManut> getAllAgendamentoByDt(DateTime dataIni, DateTime dataFim)
        {
            IQueryable<AgendaInspManut> query = _checkAppContext.AgendaInspManuts
             .Include(a => a.Funcionario)
             .Include(a => a.EmpresaCliente)
             .Include(a => a.TipoEquipamento)
             .Include(a => a.TipoAgendamento)
             .Include(a => a.StatusInspManut)
             .Include(a => a.Inspecoes).ThenInclude(i => i.EquipamentoSeguranca).ThenInclude(ES => ES.Extintor);

            return query.AsNoTracking().Where(a => a.DataInicial >= dataIni && a.DataInicial <= dataFim).OrderBy(e => e.Id).ToList();
        }

        public IEnumerable<dynamic> getAllEquipInspByDtHoje(DateTime dataIni, DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                             " +
                               "    B.RAZAOSOCIAL,                                                                                 " +
                               "    C.ID,                                                                                          " +
                               "    C.LOCALIZACAO_EQUIPAMENTO,                                                                     " +
                               "    C.QRCODE,                                                                                      " +
                               "    C.QRCODE_DATA_GERACAO,                                                                         " +
                               "    C.DATACRIACAO_EQUIPAMENTO,                                                                     " +
                               "    D.NUM_EXT,                                                                                     " +
                               "    D.SELOINMETRO_EXT,                                                                             " +
                               "    D.FABRICANTE_EXT,                                                                              " +
                               "    D.TIPO_EXT,                                                                                    " +
                               "    D.CAPACIDADE_EXT,                                                                              " +
                               "    D.ANOFABRICACAO_EXT,                                                                           " +
                               "    E.PRECISAMANUTENCAO,                                                                           " +
                               "    E.IMAGEMOCORRENCIA                                                                             " +
                               "FROM AGENDAINSPMANUT  AS A(NOLOCK)                                                                 " +
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                                " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                         " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                         " +
                               "INNER JOIN INSPECAO AS E(NOLOCK) ON E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID " +
                               "WHERE E.DATAINICIAL BETWEEN @DATA_INI AND @DATA_FIM AND A.TIPOAGENDAMENTOID = 1                    " +
                               "ORDER BY B.RAZAOSOCIAL ASC                                                                          ";

                query.AdicionarParametro("DATA_INI", dataIni);
                query.AdicionarParametro("DATA_FIM", dataFim);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
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
                    });
                }

                return lista.Count > 0 ? lista : null;

            }
        }

        public dynamic getAllQtdEquipInspByDtHoje(DateTime dataIni, DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                              " +
                               "    B.RAZAOSOCIAL,                                                                                  " +
                               "    COUNT(C.ID) AS INSPECIONADOSQTD                                                                 " +
                               "FROM AGENDAINSPMANUT  AS A(NOLOCK)                                                                  " +
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                                 " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                          " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                          " +
                               "INNER JOIN INSPECAO AS E(NOLOCK) ON E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID  " +
                               "AND E.DATAINICIAL BETWEEN @DATA_INI AND @DATA_FIM AND A.TIPOAGENDAMENTOID = 1                       " +
                               "GROUP BY B.RAZAOSOCIAL                                                                              " ;                         


                query.AdicionarParametro("DATA_INI", dataIni);
                query.AdicionarParametro("DATA_FIM", dataFim);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
                    {
                        Empresa = query.ObterString("RAZAOSOCIAL", true),
                        TotalInpecionados = query.ObterInteiro("INSPECIONADOSQTD", 0)
                    });
                }

                return lista.Count > 0 ? lista : null;
            }
        }

        public IEnumerable<dynamic> getAllEquipInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                          " +
                               "    B.RAZAOSOCIAL,                                                                              " +
                               "    C.ID,                                                                                       " +
                               "    C.LOCALIZACAO_EQUIPAMENTO,                                                                  " +
                               "    C.QRCODE,                                                                                   " +
                               "    C.QRCODE_DATA_GERACAO,                                                                      " +
                               "    C.DATACRIACAO_EQUIPAMENTO,                                                                  " +
                               "    D.NUM_EXT,                                                                                  " +
                               "    D.SELOINMETRO_EXT,                                                                          " +
                               "    D.FABRICANTE_EXT,                                                                           " +
                               "    D.TIPO_EXT,                                                                                 " +
                               "    D.CAPACIDADE_EXT,                                                                           " +
                               "    D.ANOFABRICACAO_EXT,                                                                        " +
                               "    E.PRECISAMANUTENCAO,                                                                        " +
                               "    E.IMAGEMOCORRENCIA                                                                          " +
                               "FROM AGENDAINSPMANUT  AS A(NOLOCK)                                                              " +
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                             " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                      " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                      " +
                               "INNER JOIN INSPECAO AS E(NOLOCK) ON E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID " +
                               "WHERE A.DATAINICIAL BETWEEN @DATA_INI AND @DATA_FIM AND A.TIPOAGENDAMENTOID = 1                 " +
                               "ORDER BY B.RAZAOSOCIAL ASC                                                                      ";

                query.AdicionarParametro("DATA_INI", dataIni);
                query.AdicionarParametro("DATA_FIM", dataFim);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
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
                    });
                }

                return lista.Count > 0 ? lista : null;

            }
        }

        public IEnumerable<dynamic> getAllEquipNotInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                              " +
                               "    B.RAZAOSOCIAL,                                                                                  " +
                               "    C.ID,                                                                                           " +
                               "    C.LOCALIZACAO_EQUIPAMENTO,                                                                      " +
                               "    C.QRCODE,                                                                                       " +
                               "    C.QRCODE_DATA_GERACAO,                                                                          " +
                               "    C.DATACRIACAO_EQUIPAMENTO,                                                                      " +
                               "    D.NUM_EXT,                                                                                      " +
                               "    D.SELOINMETRO_EXT,                                                                              " +
                               "    D.FABRICANTE_EXT,                                                                               " +
                               "    D.TIPO_EXT,                                                                                     " +
                               "    D.CAPACIDADE_EXT,                                                                               " +
                               "    D.ANOFABRICACAO_EXT                                                                             " +
                               "FROM AGENDAINSPMANUT  AS A(NOLOCK)                                                                  " +
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                                 " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                          " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID										    " +
                               "LEFT JOIN INSPECAO AS E(NOLOCK) ON E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID   " +
                               "WHERE A.DATAINICIAL BETWEEN @DATA_INI AND @DATA_FIM AND E.ID IS NULL AND A.TIPOAGENDAMENTOID = 1    " +
                               "ORDER BY B.RAZAOSOCIAL ASC                                                                          ";

                query.AdicionarParametro("DATA_INI", dataIni);
                query.AdicionarParametro("DATA_FIM", dataFim);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
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
                    });
                }

                return lista.Count > 0 ? lista : null;

            }
        }

        public dynamic getAllQtdEquipInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT B.RAZAOSOCIAL, COUNT(C.ID) AS INSPECIONADOSQTD FROM AGENDAINSPMANUT  AS A(NOLOCK)                                       "+
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                                                            "+
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                                                     "+
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                                                     "+
                               "WHERE EXISTS(SELECT TOP 1 1 FROM INSPECAO AS E(NOLOCK) WHERE E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID)   "+
                               "AND A.DATAINICIAL BETWEEN @DATA_INI AND @DATA_FIM AND A.TIPOAGENDAMENTOID = 1                                                     "+
                               "GROUP BY B.RAZAOSOCIAL                                                                                                         ";

                query.AdicionarParametro("DATA_INI", dataIni);
                query.AdicionarParametro("DATA_FIM", dataFim);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
                    {
                        Empresa = query.ObterString("RAZAOSOCIAL", true),
                        TotalInpecionados = query.ObterInteiro("INSPECIONADOSQTD", 0)
                    });
                }

                return lista.Count > 0 ? lista : null;
            }
        }

        public dynamic getAllQtdEquipNotInspByDtAgendamento(DateTime dataIni, DateTime dataFim)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT B.RAZAOSOCIAL, COUNT(C.ID) AS NAOINSPECIONADOSQTD FROM AGENDAINSPMANUT  AS A(NOLOCK)     " +
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                             " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                      " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                      " +
                               "WHERE NOT EXISTS(SELECT TOP 1 1 FROM INSPECAO AS E(NOLOCK) WHERE E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID)   " +
                               "AND A.DATAINICIAL BETWEEN @DATA_INI AND @DATA_FIM AND A.TIPOAGENDAMENTOID = 1                   " +
                               "GROUP BY B.RAZAOSOCIAL                                                                          ";

                query.AdicionarParametro("DATA_INI", dataIni);
                query.AdicionarParametro("DATA_FIM", dataFim);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
                    {
                        Empresa = query.ObterString("RAZAOSOCIAL", true),
                        TotalNaoInpecionados = query.ObterInteiro("NAOINSPECIONADOSQTD", 0)
                    });
                }

                return lista.Count > 0 ? lista : null;
            }
        }

        public IEnumerable<dynamic> getAllAgendaByFuncIdAndTipo(int funcionarioId, int tipoAgendamento)
        {
            DateTime data = DateTime.Today;
            DateTime primeiroDiaDoMes = new DateTime(data.Year, data.Month, 1);
            DateTime ultimoDiaDoMes = new DateTime(data.Year, data.Month, DateTime.DaysInMonth(data.Year, data.Month));

            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                   "+
                               "    EC.ID AS EMPID,                                                                      "+
                               "    F.ID AS FUNCID,                                                                      "+
                               "    AIM.ID AS AGEID,                                                                     "+
                               "    EC.RAZAOSOCIAL,                                                                      "+
                               "    F.NOME,                                                                              "+
                               "    AIM.DATAINICIAL,                                                                     "+
                               "    TA.TIPOAGENDA,                                                                       "+
                               "    SIM.STATUSAGENDA,                                                                    "+
                               "    TE.Tipo,                                                                             "+
                               "    EC.IMAGEMURL,                                                                        "+
                               "    AIM.TIPOMANUTENCAO,                                                                  "+
                               "    AIM.OCORRENCIAINSPECAO                                                               "+
                               "FROM                                                                                     "+
                               "    USUARIO AS U(NOLOCK)                                                                 "+
                               "    INNER JOIN FUNCIONARIO AS F(NOLOCK) ON U.ID = F.USUARIOID                            "+
                               "    INNER JOIN AGENDAINSPMANUT AS AIM(NOLOCK) ON AIM.FUNCIONARIOID = F.ID                "+
                               "    INNER JOIN EMPRESACLIENTE AS EC(NOLOCK) ON EC.ID = AIM.EMPRESACLIENTEID              "+
                               "    INNER JOIN TIPOAGENDAMENTO AS TA(NOLOCK) ON TA.ID = AIM.TIPOAGENDAMENTOID            "+
                               "    INNER JOIN STATUSINSPMANUT AS SIM(NOLOCK) ON SIM.ID = AIM.STATUSINSPMANUTID          "+
                               "    INNER JOIN TIPO_EQUIPAMENTO AS TE(NOLOCK) ON TE.ID = AIM.TIPOEQUIPAMENTOID           "+
                               "WHERE                                                                                    "+
                               "    F.Id = @FUNCID AND SIM.Id IN(1,2) AND AIM.TIPOAGENDAMENTOID = @TPAID AND             " +
                               "    AIM.DATAINICIAL BETWEEN @DATA_INI AND @DATA_FIM                                      ";                                                             
                                                                                                                        
                query.AdicionarParametro("FUNCID", funcionarioId);
                query.AdicionarParametro("DATA_INI", primeiroDiaDoMes);
                query.AdicionarParametro("DATA_FIM", ultimoDiaDoMes);
                query.AdicionarParametro("TPAID", tipoAgendamento);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
                    {
                        EmpId = query.ObterInteiro("EMPID", 0),
                        FuncId = query.ObterInteiro("FUNCID", 0),
                        AgeId = query.ObterInteiro("AGEID", 0),
                        Empresa = query.ObterString("RAZAOSOCIAL", true),
                        NomeFunc = query.ObterString("NOME", true),
                        Data = query.ObterDateTime("DATAINICIAL"),
                        TipoAgenda = query.ObterString("TIPOAGENDA", true),
                        StatusAgenda = query.ObterString("STATUSAGENDA", true),
                        TipoEquip = query.ObterString("Tipo", true),
                        TipoManut = query.ObterString("TIPOMANUTENCAO", true),
                        OcorrenciaInsp = query.ObterString("OCORRENCIAINSPECAO", true),
                        ImagemUrl = Utilidades.ImgToBase64(query.ObterString("IMAGEMURL", true)),
                        QtdNotInsp = GetAllEquipNotInsp(query.ObterInteiro("FUNCID", 0), query.ObterInteiro("EMPID", 0), query.ObterInteiro("AGEID", 0)),
                        QtdInsp = GetAllEquipInsp(query.ObterInteiro("FUNCID", 0), query.ObterInteiro("EMPID", 0), query.ObterInteiro("AGEID", 0)),
                        QtdNotManut = GetAllEquipNotManut(query.ObterInteiro("FUNCID", 0), query.ObterInteiro("EMPID", 0), query.ObterInteiro("AGEID", 0)),
                        QtdManut = GetAllEquipManut(query.ObterInteiro("FUNCID", 0), query.ObterInteiro("EMPID", 0), query.ObterInteiro("AGEID", 0))
                    });
                }

                return lista.Count > 0 ? lista : null;
            }
        }

        public int GetAllEquipInsp(int funcionarioId, int empresaId, int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = " SELECT                                                                                                                                                                 " +
                                "    COUNT(EC.ID) AS QTDINSPECIONADOS                                                                                                                                   " +
                                "FROM                                                                                                                                                                   " +
                                "    USUARIO AS U(NOLOCK)                                                                                                                                               " +
                                "    INNER JOIN FUNCIONARIO AS F(NOLOCK) ON U.ID = F.USUARIOID                                                                                                          " +
                                "    INNER JOIN AGENDAINSPMANUT AS AIM(NOLOCK) ON AIM.FUNCIONARIOID = F.ID                                                                                              " +
                                "    INNER JOIN EMPRESACLIENTE AS EC(NOLOCK) ON EC.ID = AIM.EMPRESACLIENTEID                                                                                            " +
                                "    INNER JOIN Equipamento_Seguranca AS ES(NOLOCK) ON ES.EmpresaClienteId = EC.Id                                                                                      " +
                                "    INNER JOIN Inspecao AS I(NOLOCK) ON(F.ID = I.FUNCIONARIOID AND EC.ID = I.EMPRESACLIENTEID AND AIM.ID = I.AGENDAINSPMANUTID AND ES.ID = I.EquipamentoSegurancaId)   " +
                                "WHERE                                                                                                                                                                  " +
                                "    F.ID = @FUNCID AND EC.ID = @EMPID AND AIM.Id = @AGEID AND AIM.TIPOAGENDAMENTOID = 1                                                                                ";

                query.AdicionarParametro("FUNCID", funcionarioId);
                query.AdicionarParametro("EMPID", empresaId);
                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                while (query.Proximo())
                    return query.ObterInteiro("QTDINSPECIONADOS", 0);

                return 0;
            }
        }

        public int GetAllEquipNotInsp(int funcionarioId, int empresaId, int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script =  "SELECT                                                                                                                                                                 " +
                                "    COUNT(EC.ID) AS QTDNOTINSPECIONADOS                                                                                                                                " +
                                "FROM                                                                                                                                                                   " +                    
                                "    USUARIO AS U(NOLOCK)                                                                                                                                               " +
                                "    INNER JOIN FUNCIONARIO AS F(NOLOCK) ON U.ID = F.USUARIOID                                                                                                          " +
                                "    INNER JOIN AGENDAINSPMANUT AS AIM(NOLOCK) ON AIM.FUNCIONARIOID = F.ID                                                                                              " +
                                "    INNER JOIN EMPRESACLIENTE AS EC(NOLOCK) ON EC.ID = AIM.EMPRESACLIENTEID                                                                                            " +
                                "    INNER JOIN Equipamento_Seguranca AS ES(NOLOCK) ON ES.EmpresaClienteId = EC.Id                                                                                      " +
                                "    LEFT JOIN Inspecao AS I(NOLOCK) ON(F.ID = I.FUNCIONARIOID AND EC.ID = I.EMPRESACLIENTEID AND AIM.ID = I.AGENDAINSPMANUTID AND ES.ID = I.EquipamentoSegurancaId)    " +
                                "WHERE                                                                                                                                                                  " +
                                "    F.ID = @FUNCID AND EC.ID = @EMPID AND AIM.Id = @AGEID AND AIM.TIPOAGENDAMENTOID = 1 AND I.ID IS NULL                                                               ";

                query.AdicionarParametro("FUNCID", funcionarioId);
                query.AdicionarParametro("EMPID", empresaId);
                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                while(query.Proximo())
                    return query.ObterInteiro("QTDNOTINSPECIONADOS", 0);

                return 0;
            }
        }

        public int GetAllEquipManut(int funcionarioId, int empresaId, int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = " SELECT                                                                                                                                                                 " +
                                "    COUNT(EC.ID) AS QTDMANUTENIDOS                                                                                                                                   " +
                                "FROM                                                                                                                                                                   " +
                                "    USUARIO AS U(NOLOCK)                                                                                                                                               " +
                                "    INNER JOIN FUNCIONARIO AS F(NOLOCK) ON U.ID = F.USUARIOID                                                                                                          " +
                                "    INNER JOIN AGENDAINSPMANUT AS AIM(NOLOCK) ON AIM.FUNCIONARIOID = F.ID                                                                                              " +
                                "    INNER JOIN EMPRESACLIENTE AS EC(NOLOCK) ON EC.ID = AIM.EMPRESACLIENTEID                                                                                            " +
                                "    INNER JOIN Equipamento_Seguranca AS ES(NOLOCK) ON ES.EmpresaClienteId = EC.Id                                                                                      " +
                                "    INNER JOIN MANUTENCAO AS I(NOLOCK) ON(F.ID = I.FUNCIONARIOID AND EC.ID = I.EMPRESACLIENTEID AND AIM.ID = I.AGENDAINSPMANUTID AND ES.ID = I.EquipamentoSegurancaId)   " +
                                "WHERE                                                                                                                                                                  " +
                                "    F.ID = @FUNCID AND EC.ID = @EMPID AND AIM.Id = @AGEID AND AIM.TIPOAGENDAMENTOID = 2                                                                                     ";

                query.AdicionarParametro("FUNCID", funcionarioId);
                query.AdicionarParametro("EMPID", empresaId);
                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                while (query.Proximo())
                    return query.ObterInteiro("QTDMANUTENIDOS", 0);

                return 0;
            }
        }

        public int GetAllEquipNotManut(int funcionarioId, int empresaId, int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                                                                                                  " +
                                "    COUNT(EC.ID) AS QTDNOTMANUTENIDOS                                                                                                                                  " +
                                "FROM                                                                                                                                                                   " +
                                "    USUARIO AS U(NOLOCK)                                                                                                                                               " +
                                "    INNER JOIN FUNCIONARIO AS F(NOLOCK) ON U.ID = F.USUARIOID                                                                                                          " +
                                "    INNER JOIN AGENDAINSPMANUT AS AIM(NOLOCK) ON AIM.FUNCIONARIOID = F.ID                                                                                              " +
                                "    INNER JOIN EMPRESACLIENTE AS EC(NOLOCK) ON EC.ID = AIM.EMPRESACLIENTEID                                                                                            " +
                                "    INNER JOIN Equipamento_Seguranca AS ES(NOLOCK) ON ES.EmpresaClienteId = EC.Id                                                                                      " +
                                "    LEFT JOIN MANUTENCAO AS I(NOLOCK) ON(F.ID = I.FUNCIONARIOID AND EC.ID = I.EMPRESACLIENTEID AND AIM.ID = I.AGENDAINSPMANUTID AND ES.ID = I.EquipamentoSegurancaId)  " +
                                "WHERE                                                                                                                                                                  " +
                                "    F.ID = @FUNCID AND EC.ID = @EMPID AND AIM.Id = @AGEID AND AIM.TIPOAGENDAMENTOID = 2 AND I.ID IS NULL                                                               ";

                query.AdicionarParametro("FUNCID", funcionarioId);
                query.AdicionarParametro("EMPID", empresaId);
                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                while (query.Proximo())
                    return query.ObterInteiro("QTDNOTMANUTENIDOS", 0);

                return 0;
            }
        }

        public void alteraStatusAgendamentoById(int ageId, int statusId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "UPDATE                            " +
                                "    AGENDAINSPMANUT              " +
                                "SET                              " +
                                "    STATUSINSPMANUTID = @STSIID  " +
                                "WHERE                            " +
                                "   ID = @AGEID                   ";

                query.AdicionarParametro("AGEID", ageId);
                query.AdicionarParametro("STSIID", statusId);
                query.Executar();

            }
        }

        public IEnumerable<dynamic> getAllEquipInspByAgendamentoId(int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                             " +
                               "    B.RAZAOSOCIAL,                                                                                 " +
                               "    C.ID,                                                                                          " +
                               "    C.LOCALIZACAO_EQUIPAMENTO,                                                                     " +
                               "    C.QRCODE,                                                                                      " +
                               "    C.QRCODE_DATA_GERACAO,                                                                         " +
                               "    C.DATACRIACAO_EQUIPAMENTO,                                                                     " +
                               "    D.NUM_EXT,                                                                                     " +
                               "    D.SELOINMETRO_EXT,                                                                             " +
                               "    D.FABRICANTE_EXT,                                                                              " +
                               "    D.TIPO_EXT,                                                                                    " +
                               "    D.CAPACIDADE_EXT,                                                                              " +
                               "    D.ANOFABRICACAO_EXT,                                                                           " +
                               "    E.PRECISAMANUTENCAO                                                                            " +
                               "FROM AGENDAINSPMANUT  AS A(NOLOCK)                                                                 " +
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                                " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                         " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                         " +
                               "INNER JOIN INSPECAO AS E(NOLOCK) ON E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID " +
                               "WHERE A.ID = @AGEID                                                                                " +
                               "ORDER BY B.RAZAOSOCIAL ASC                                                                          ";

                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
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
                    });
                }

                return lista.Count > 0 ? lista : null;
            }
        }

        public IEnumerable<dynamic> getAllEquipNotInspByAgendamentoId(int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                             " +
                               "    B.RAZAOSOCIAL,                                                                                 " +
                               "    C.ID,                                                                                          " +
                               "    C.LOCALIZACAO_EQUIPAMENTO,                                                                     " +
                               "    C.QRCODE,                                                                                      " +
                               "    C.QRCODE_DATA_GERACAO,                                                                         " +
                               "    C.DATACRIACAO_EQUIPAMENTO,                                                                     " +
                               "    D.NUM_EXT,                                                                                     " +
                               "    D.SELOINMETRO_EXT,                                                                             " +
                               "    D.FABRICANTE_EXT,                                                                              " +
                               "    D.TIPO_EXT,                                                                                    " +
                               "    D.CAPACIDADE_EXT,                                                                              " +
                               "    D.ANOFABRICACAO_EXT                                                                            " +
                               "FROM AGENDAINSPMANUT  AS A(NOLOCK)                                                                 " +
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                                " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                         " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                         " +
                               "LEFT  JOIN INSPECAO AS E(NOLOCK) ON E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID " +
                               "WHERE A.ID = @AGEID AND E.ID IS NULL                                                               " +
                               "ORDER BY B.RAZAOSOCIAL ASC                                                                         ";

                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
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
                    });
                }

                return lista.Count > 0 ? lista : null;
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

        public IEnumerable<dynamic> getAllEquipManutByAgendamentoId(int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                             " +
                               "    B.RAZAOSOCIAL,                                                                                 " +
                               "    C.ID,                                                                                          " +
                               "    C.LOCALIZACAO_EQUIPAMENTO,                                                                     " +
                               "    C.QRCODE,                                                                                      " +
                               "    C.QRCODE_DATA_GERACAO,                                                                         " +
                               "    C.DATACRIACAO_EQUIPAMENTO,                                                                     " +
                               "    D.NUM_EXT,                                                                                     " +
                               "    D.SELOINMETRO_EXT,                                                                             " +
                               "    D.FABRICANTE_EXT,                                                                              " +
                               "    D.TIPO_EXT,                                                                                    " +
                               "    D.CAPACIDADE_EXT,                                                                              " +
                               "    D.ANOFABRICACAO_EXT                                                                            " +
                               "FROM AGENDAINSPMANUT  AS A(NOLOCK)                                                                 " +
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                                " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                         " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                         " +
                               "INNER JOIN MANUTENCAO AS E(NOLOCK) ON E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID " +
                               "WHERE A.ID = @AGEID                                                                                " +
                               "ORDER BY B.RAZAOSOCIAL ASC                                                                          ";

                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
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
                    });
                }

                return lista.Count > 0 ? lista : null;
            }
        }

        public IEnumerable<dynamic> getAllEquipNotManutByAgendamentoId(int agendamentoId)
        {
            using (Query query = new Query(_stringConexao))
            {
                query.Script = "SELECT                                                                                               " +
                               "    B.RAZAOSOCIAL,                                                                                   " +
                               "    C.ID,                                                                                            " +
                               "    C.LOCALIZACAO_EQUIPAMENTO,                                                                       " +
                               "    C.QRCODE,                                                                                        " +
                               "    C.QRCODE_DATA_GERACAO,                                                                           " +
                               "    C.DATACRIACAO_EQUIPAMENTO,                                                                       " +
                               "    D.NUM_EXT,                                                                                       " +
                               "    D.SELOINMETRO_EXT,                                                                               " +
                               "    D.FABRICANTE_EXT,                                                                                " +
                               "    D.TIPO_EXT,                                                                                      " +
                               "    D.CAPACIDADE_EXT,                                                                                " +
                               "    D.ANOFABRICACAO_EXT                                                                              " +
                               "FROM AGENDAINSPMANUT  AS A(NOLOCK)                                                                   " +
                               "INNER JOIN EMPRESACLIENTE AS B(NOLOCK) ON A.EMPRESACLIENTEID = B.ID                                  " +
                               "INNER JOIN EQUIPAMENTO_SEGURANCA AS C(NOLOCK) ON B.ID = C.EMPRESACLIENTEID                           " +
                               "INNER JOIN EXTINTOR AS D(NOLOCK) ON D.EQUIPAMENTOID = C.ID                                           " +
                               "LEFT  JOIN MANUTENCAO AS E(NOLOCK) ON E.EQUIPAMENTOSEGURANCAID = C.ID AND E.AGENDAINSPMANUTID = A.ID " +
                               "WHERE A.ID = @AGEID AND E.ID IS NULL                                                                 " +
                               "ORDER BY B.RAZAOSOCIAL ASC                                                                           ";

                query.AdicionarParametro("AGEID", agendamentoId);
                query.Abrir();

                List<dynamic> lista = new List<dynamic>();

                while (query.Proximo())
                {
                    lista.Add(new
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
                    });
                }

                return lista.Count > 0 ? lista : null;
            }
        }

        public AgendaInspManut getUltimoAgendamento()
        {
            IQueryable<AgendaInspManut> query = _checkAppContext.AgendaInspManuts
                .Include(a => a.Funcionario)
                .Include(a => a.EmpresaCliente)
                .Include(a => a.TipoEquipamento)
                .Include(a => a.TipoAgendamento)
                .Include(a => a.StatusInspManut);

            return query.AsNoTracking().OrderByDescending(e => e.Id).Take(1).FirstOrDefault();
        }

        public void finalizaAgendamentoById(int ageId)
        {
            using (Query query = new Query(_stringConexao))
            {
                DateTime dataAtual = DateTime.Now;
                query.Script = "UPDATE                            " +
                                "    AGENDAINSPMANUT              " +
                                "SET                              " +
                                "    STATUSINSPMANUTID = 3,       " +
                                "    DATAFINAL = @DATATUAL        " +
                                "WHERE                            " +
                                "   ID = @AGEID                   ";

                query.AdicionarParametro("AGEID", ageId);
                query.AdicionarParametro("DATATUAL", dataAtual);
                query.Executar();

            }
        }
    }
}
