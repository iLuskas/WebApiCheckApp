using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;

namespace WebApiCheckApp.Controllers
{
    public class ExtintorController : ControllerBase
    {
        private readonly IApplicationServiceExtintor _applicationServiceExtintor;

        public ExtintorController(IApplicationServiceExtintor applicationServiceExtintor)
        {
            _applicationServiceExtintor = applicationServiceExtintor;
        }

        // GET api/listValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_applicationServiceExtintor.GetAll());
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
                return Ok(_applicationServiceExtintor.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ExtintorDTO extintorDTO)
        {
            try
            {
                if (extintorDTO == null)
                    return NotFound(new { message = "Extintor inválido!" });

                _applicationServiceExtintor.Add(extintorDTO);
                return Ok("Extintor Cadastrado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody] ExtintorDTO extintorDTO)
        {
            try
            {
                if (extintorDTO == null)
                    return NotFound(new { message = "Extintor inválidos!" });

                _applicationServiceExtintor.Update(extintorDTO);
                return Ok("Extintor Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult Delete([FromBody] ExtintorDTO extintorDTO)
        {
            try
            {
                if (extintorDTO == null)
                    return NotFound(new { message = "Extintor inválidos!" });

                _applicationServiceExtintor.Remove(extintorDTO);
                return Ok("Extintor Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}