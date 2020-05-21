using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;

namespace WebApiCheckApp.Controllers
{
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