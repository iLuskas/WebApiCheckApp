using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;

namespace WebApiCheckApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Equipamento_SegurancaController : ControllerBase
    {
        private readonly IApplicationServiceEquipamento_Seguranca _applicationServiceEquipamento_Seguranca;

        public Equipamento_SegurancaController(IApplicationServiceEquipamento_Seguranca applicationServiceEquipamento_Seguranca)
        {
            _applicationServiceEquipamento_Seguranca = applicationServiceEquipamento_Seguranca;
        }

        // GET api/listValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_applicationServiceEquipamento_Seguranca.GetAll());
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
                return Ok(_applicationServiceEquipamento_Seguranca.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // GET  api/getAllInfoEmpresaClienteById/id
        [HttpGet("getEquipamentoById/{id}")]
        public ActionResult<string> getEquipamentoById(int id)
        {
            try
            {
                return Ok(_applicationServiceEquipamento_Seguranca.getEquipamentoById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }
        }

        // GET  api/getAllEquipamentoByEmpresaId/id
        [HttpGet("getAllEquipamentoByEmpresaId/{id}")]
        public ActionResult<string> getAllEquipamentoByEmpresaId(int id)
        {
            try
            {
                return Ok(_applicationServiceEquipamento_Seguranca.getAllEquipamentoByEmpresaId(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }
        }

        // GET  api/getAllInfoEmpresaClienteById?id=1&tipoId=2
        [HttpGet("getAllEquipamento")]
        public ActionResult<IEnumerable<string>> getAllEquipamento()
        {
            try
            {
                return Ok(_applicationServiceEquipamento_Seguranca.getAllEquipamento());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // GET  api/getAllEquipamentoByEmpresaIdAndTipo?id=1&tipoId=2
        [HttpGet("getAllEquipamentoByEmpresaIdAndTipo")]
        public ActionResult<string> getAllEquipamentoByEmpresaIdAndTipo([FromQuery] int id, [FromQuery] int tipoId)
        {
            try
            {
                return Ok(_applicationServiceEquipamento_Seguranca.getAllEquipamentoByEmpresaIdAndTipo(id, tipoId));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Equipamento_SegurancaDTO equipamento_SegurancaDTO)
        {
            try
            {
                if (equipamento_SegurancaDTO == null)
                    return NotFound(new { message = "Equipamento de Segurança inválido!" });

                _applicationServiceEquipamento_Seguranca.Add(equipamento_SegurancaDTO);
                return Ok("Equipamento de Segurança Cadastrado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody] Equipamento_SegurancaDTO equipamento_SegurancaDTO)
        {
            try
            {
                if (equipamento_SegurancaDTO == null)
                    return NotFound(new { message = "Equipamento de Segurança inválidos!" });

                _applicationServiceEquipamento_Seguranca.Update(equipamento_SegurancaDTO);
                return Ok("Equipamento de Segurança Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult Delete([FromBody] Equipamento_SegurancaDTO equipamento_SegurancaDTO)
        {
            try
            {
                if (equipamento_SegurancaDTO == null)
                    return NotFound(new { message = "Equipamento de Segurança inválidos!" });

                _applicationServiceEquipamento_Seguranca.Remove(equipamento_SegurancaDTO);
                return Ok("Equipamento de Segurança Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}