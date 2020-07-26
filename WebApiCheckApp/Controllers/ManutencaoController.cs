using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;
using WebApiCheckApp.Domain.Models;

namespace WebApiCheckApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManutencaoController : ControllerBase
    {
        private readonly IApplicationServiceManutencao _applicationServiceManutencao;

        public ManutencaoController(IApplicationServiceManutencao applicationServiceManutencao)
        {
            _applicationServiceManutencao = applicationServiceManutencao;
        }

        // GET api/listValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_applicationServiceManutencao.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALL. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(_applicationServiceManutencao.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // GET api/values
        [HttpGet("GetManutencaoByEquipIdAndAgeId")]
        public ActionResult<string> GetManutencaoByEquipIdAndAgeId([FromQuery] int equipamentoId, int agendamentoId)
        {
            try
            {
                return Ok(_applicationServiceManutencao.GetManutencaoByEquipIdAndAgeId(equipamentoId, agendamentoId));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETMANUTENCAOBYEQUIPIDANDAGEID. {ex.Message}");
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ManutencaoDTO manutencao)
        {
            try
            {
                if (manutencao == null)
                    return NotFound(new { message = "Manutenção inválido!" });

                _applicationServiceManutencao.Add(manutencao);
                return Ok("Manutenção Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST" + ex.Message);
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody] ManutencaoDTO manutencao)
        {
            try
            {
                if (manutencao == null)
                    return NotFound(new { message = "Manutenção inválidos!" });

                _applicationServiceManutencao.Update(manutencao);
                return Ok("Manutenção Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult Delete([FromBody] ManutencaoDTO manutencao)
        {
            try
            {
                if (manutencao == null)
                    return NotFound(new { message = "Manutenção inválidos!" });

                _applicationServiceManutencao.Remove(manutencao);
                return Ok("Manutenção Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}