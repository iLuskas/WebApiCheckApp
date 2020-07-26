using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IApplicationServiceAgendaInspManut _applicationServiceAgendaInspManut;
        private readonly IApplicationServiceStatusInspManut _applicationServiceStatusInspManut;
        private readonly IApplicationServiceTipoAgenda _applicationServiceTipoAgenda;

        public AgendamentoController(IApplicationServiceAgendaInspManut applicationServiceAgendaInspManut, IApplicationServiceStatusInspManut applicationServiceStatusInspManut, IApplicationServiceTipoAgenda applicationServiceTipoAgenda)
        {
            _applicationServiceAgendaInspManut = applicationServiceAgendaInspManut;
            _applicationServiceStatusInspManut = applicationServiceStatusInspManut;
            _applicationServiceTipoAgenda = applicationServiceTipoAgenda;
        }

        //AGENDAMENTOSCONTROLLER

        // GET api/listValues
        [HttpGet("getAllAgendamento")]
        public ActionResult<IEnumerable<string>> getAllAgendamento()
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllAgendamento());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLAGENDAMENTO. {ex.Message}");
            }

        }

        [HttpGet("getAllAgendamentoByDt")]
        public ActionResult<IEnumerable<string>> getAllAgendamentoByDt([FromQuery] DateTime dataIni, [FromQuery] DateTime dataFim)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllAgendamentoByDt(dataIni, dataFim));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLAGENDAMENTO. {ex.Message}");
            }

        }

        // GET api/listValues
        [HttpGet("getAllEquipInspByDtAgendamento")]
        public ActionResult<IEnumerable<string>> getAllEquipInspByDtAgendamento([FromQuery] DateTime dataIni, [FromQuery] DateTime dataFim)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllEquipInspByDtAgendamento(dataIni, dataFim));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLAGENDAMENTO. {ex.Message}");
            }

        }


        // GET api/listValues
        [HttpGet("getAllEquipNotInspByDtAgendamento")]
        public ActionResult<IEnumerable<string>> getAllEquipNotInspByDtAgendamento([FromQuery] DateTime dataIni, [FromQuery] DateTime dataFim)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllEquipNotInspByDtAgendamento(dataIni, dataFim));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLAGENDAMENTO. {ex.Message}");
            }

        }

        // GET api/listValues
        [HttpGet("getAllEquipInspByDtHoje")]
        public ActionResult<IEnumerable<string>> getAllEquipInspByDtHoje([FromQuery] DateTime dataIni, [FromQuery] DateTime dataFim)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllEquipInspByDtHoje(dataIni, dataFim));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLAGENDAMENTO. {ex.Message}");
            }

        }


        // GET api/listValues
        [HttpGet("getAllQtdEquipInspByDtAgendamento")]
        public ActionResult<IEnumerable<string>> getAllQtdEquipInspByDtAgendamento([FromQuery] DateTime dataIni, [FromQuery] DateTime dataFim)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllQtdEquipInspByDtAgendamento(dataIni, dataFim));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLAGENDAMENTO. {ex.Message}");
            }

        }

        // GET api/listValues
        [HttpGet("getAllQtdEquipNotInspByDtAgendamento")]
        public ActionResult<IEnumerable<string>> getAllQtdEquipNotInspByDtAgendamento([FromQuery] DateTime dataIni, [FromQuery] DateTime dataFim)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllQtdEquipNotInspByDtAgendamento(dataIni, dataFim));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLAGENDAMENTO. {ex.Message}");
            }

        }

        // GET api/listValues
        [HttpGet("getAllQtdEquipInspByDtHoje")]
        public ActionResult<IEnumerable<string>> getAllQtdEquipInspByDtHoje([FromQuery] DateTime dataIni, [FromQuery] DateTime dataFim)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllQtdEquipInspByDtHoje(dataIni, dataFim));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLAGENDAMENTO. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("getAgendamentoById/{id}")]
        public ActionResult<string> getAgendamentoById(int id)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAgendamentoById(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETAGENDAMENTOBYID. {ex.Message}");
            }

        }


        // GET  api/values/id
        [HttpGet("getAllAgendaByUserAndTipo")]
        public ActionResult<string> getAllAgendaByUserAndTipo([FromQuery] string usuario, [FromQuery] int tipoAgendamento)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllAgendaByUserAndTipo(usuario, tipoAgendamento));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETAGENDAMENTOBYID. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("GetAllEquipInsp")]
        public ActionResult<string> GetAllEquipInsp([FromQuery] int funcionarioId, [FromQuery] int empresaId, [FromQuery] int agendamentoId)
        { 
            try
            {
                return Ok(_applicationServiceAgendaInspManut.GetAllEquipInsp(funcionarioId, empresaId, agendamentoId));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETAGENDAMENTOBYID. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("GetAllEquipNotInsp")]
        public ActionResult<string> GetAllEquipNotInsp([FromQuery] int funcionarioId, [FromQuery] int empresaId, [FromQuery] int agendamentoId)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.GetAllEquipNotInsp(funcionarioId, empresaId, agendamentoId));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETAGENDAMENTOBYID. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("getAllEquipInspByAgendamentoId")]
        public ActionResult<string> getAllEquipInspByAgendamentoId([FromQuery] int agendamentoId)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllEquipInspByAgendamentoId(agendamentoId));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLEQUIPINSPBYAGENDAMENTOID. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("getAllEquipNotInspByAgendamentoId")]
        public ActionResult<string> getAllEquipNotInspByAgendamentoId([FromQuery] int agendamentoId)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllEquipNotInspByAgendamentoId(agendamentoId));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLEQUIPNOTINSPBYAGENDAMENTOID. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("getAllEquipManutByAgendamentoId")]
        public ActionResult<string> getAllEquipManutByAgendamentoId([FromQuery] int agendamentoId)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllEquipManutByAgendamentoId(agendamentoId));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLEQUIPMANUTBYAGENDAMENTOID. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("getAllEquipNotManutByAgendamentoId")]
        public ActionResult<string> getAllEquipNotManutByAgendamentoId([FromQuery] int agendamentoId)
        {
            try
            {
                return Ok(_applicationServiceAgendaInspManut.getAllEquipNotManutByAgendamentoId(agendamentoId));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLEQUIPNOTMANUTBYAGENDAMENTOID. {ex.Message}");
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult post([FromBody] AgendaInspManut agendaInspManut)
        {
            try
            {
                if (agendaInspManut == null)
                    return NotFound(new { message = "Agendamento inválido!" });

                _applicationServiceAgendaInspManut.Add(agendaInspManut);
                return Ok("Agendamento Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método POSTAGENDAMENTO. {ex.Message}");
            }
        }

        // PUT api/values/obj
        [HttpPost("finalizaAgendamentoById")]
        public ActionResult finalizaAgendamentoById([FromQuery] int ageId)
        {
            try
            {
                _applicationServiceAgendaInspManut.finalizaAgendamentoById(ageId);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método FINALIZAAGENDAMENTOBYID. {ex.Message}");
            }
        }

        // PUT api/values/obj
        [HttpPut("alteraStatusAgendamentoById")]
        public ActionResult alteraStatusAgendamentoById([FromQuery] int ageId, [FromQuery] int statusId)
        {
            try
            {
                _applicationServiceAgendaInspManut.alteraStatusAgendamentoById(ageId, statusId);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método PUTAGENDAMENTO. {ex.Message}");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult put([FromBody] AgendaInspManut agendaInspManut)
        {
            try
            {
                if (agendaInspManut == null)
                    return NotFound(new { message = "Agendamento inválido!" });

                _applicationServiceAgendaInspManut.Update(agendaInspManut);
                return Ok("Agendamento alterado com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método PUTAGENDAMENTO. {ex.Message}");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult delete([FromBody] AgendaInspManut agendaInspManut)
        {
            try
            {
                if (agendaInspManut == null)
                    return NotFound(new { message = "Agendamento inválida!" });

                _applicationServiceAgendaInspManut.Remove(agendaInspManut);
                return Ok("Agendamento Removido com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método DELETEAGENDAMENTO. {ex.Message}");
            }

        }

        //STATUSAGENDACONTROLLER

        // GET api/listValues
        [HttpGet("getAllStatus")]
        public ActionResult<IEnumerable<string>> getAllStatus()
        {
            try
            {
                return Ok(_applicationServiceStatusInspManut.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLSTATUS. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("getStatusById/{id}")]
        public ActionResult<string> getStatusById(int id)
        {
            try
            {
                return Ok(_applicationServiceStatusInspManut.GetById(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETAGENDAMENTOBYID. {ex.Message}");
            }

        }

        // POST api/values
        [HttpPost("postStatus")]
        public ActionResult postStatus([FromBody] StatusInspManut statusInspManut)
        {
            try
            {
                if (statusInspManut == null)
                    return NotFound(new { message = "Status inválido!" });

                _applicationServiceStatusInspManut.Add(statusInspManut);
                return Ok("Status Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método POSTAGENDAMENTO. {ex.Message}");
            }
        }

        // PUT api/values/obj
        [HttpPut("putStatus")]
        public ActionResult PutStatus([FromBody] StatusInspManut statusInspManut)
        {
            try
            {
                if (statusInspManut == null)
                    return NotFound(new { message = "Status inválido!" });

                _applicationServiceStatusInspManut.Update(statusInspManut);
                return Ok("Status alterado com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método PUTAGENDAMENTO. {ex.Message}");
            }
        }

        // DELETE api/values/obj
        [HttpDelete("deleteStatus")]
        public ActionResult deleteStatus([FromBody] StatusInspManut statusInspManut)
        {
            try
            {
                if (statusInspManut == null)
                    return NotFound(new { message = "Status inválida!" });

                _applicationServiceStatusInspManut.Remove(statusInspManut);
                return Ok("Status Removido com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método DELETEAGENDAMENTO. {ex.Message}");
            }

        }


        //TIPOAGENDACONTROLLER

        // GET api/listValues
        [HttpGet("getAllTipoAgenda")]
        public ActionResult<IEnumerable<string>> getAllTipoAgenda()
        {
            try
            {
                return Ok(_applicationServiceTipoAgenda.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALLTIPOAGENDA. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("getTipoAgendaById/{id}")]
        public ActionResult<string> getTipoAgendaById(int id)
        {
            try
            {
                return Ok(_applicationServiceTipoAgenda.GetById(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETTIPOAGENDABYID. {ex.Message}");
            }

        }
    }
}
