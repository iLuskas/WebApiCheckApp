using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCheckApp.Application.DTO.DTO;
using WebApiCheckApp.Application.Interfaces;

namespace WebApiCheckApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IApplicationServicePerfil _applicationServicePerfil;

        public PerfilController(IApplicationServicePerfil applicationServicePerfil)
        {
            _applicationServicePerfil = applicationServicePerfil;
        }

        // GET api/listValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_applicationServicePerfil.GetAll());
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
                return Ok(_applicationServicePerfil.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] PerfilDTO perfilDTO)
        {
            try
            {
                if (perfilDTO == null)
                    return NotFound(new { message = "Perfil inválido!" });

                _applicationServicePerfil.Add(perfilDTO);
                return Ok("Perfil Cadastrado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody] PerfilDTO perfilDTO)
        {
            try
            {
                if (perfilDTO == null)
                    return NotFound(new { message = "Perfil inválidos!" });

                _applicationServicePerfil.Update(perfilDTO);
                return Ok("Perfil Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult Delete([FromBody] PerfilDTO perfilDTO)
        {
            try
            {
                if (perfilDTO == null)
                    return NotFound(new { message = "Perfil inválidos!" });

                _applicationServicePerfil.Remove(perfilDTO);
                return Ok("Perfil Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}