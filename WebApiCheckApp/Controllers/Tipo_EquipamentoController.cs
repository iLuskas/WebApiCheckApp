using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;

namespace WebApiCheckApp.Controllers
{
    public class Tipo_EquipamentoController : ControllerBase
    {
        private readonly IApplicationServiceTipo_equipamento _applicationServiceTipo_Equipamento;

        public Tipo_EquipamentoController(IApplicationServiceTipo_equipamento applicationServiceTipo_Equipamento)
        {
            _applicationServiceTipo_Equipamento = applicationServiceTipo_Equipamento;
        }

        // GET api/listValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_applicationServiceTipo_Equipamento.GetAll());
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
                return Ok(_applicationServiceTipo_Equipamento.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Tipo_EquipamentoDTO tipo_EquipamentoDTO)
        {
            try
            {
                if (tipo_EquipamentoDTO == null)
                    return NotFound(new { message = "Tipo de Equipamento inválido!" });

                _applicationServiceTipo_Equipamento.Add(tipo_EquipamentoDTO);
                return Ok("Tipo de Equipamento Cadastrado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody] Tipo_EquipamentoDTO tipo_EquipamentoDTO)
        {
            try
            {
                if (tipo_EquipamentoDTO == null)
                    return NotFound(new { message = "Tipo de Equipamento inválidos!" });

                _applicationServiceTipo_Equipamento.Update(tipo_EquipamentoDTO);
                return Ok("Tipo de Equipamento Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult Delete([FromBody] Tipo_EquipamentoDTO tipo_EquipamentoDTO)
        {
            try
            {
                if (tipo_EquipamentoDTO == null)
                    return NotFound(new { message = "Tipo de Equipamento inválidos!" });

                _applicationServiceTipo_Equipamento.Remove(tipo_EquipamentoDTO);
                return Ok("Tipo de Equipamento Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}