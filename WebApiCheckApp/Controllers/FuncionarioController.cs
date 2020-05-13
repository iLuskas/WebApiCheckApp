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
    public class FuncionarioController : ControllerBase
    {
        private readonly IApplicationServiceFuncionario _applicationServiceFuncionario;

        public FuncionarioController(IApplicationServiceFuncionario applicationServiceFuncionario)
        {
            _applicationServiceFuncionario = applicationServiceFuncionario;
        }

        // GET api/listValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_applicationServiceFuncionario.GetAll());
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
                return Ok(_applicationServiceFuncionario.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // GET api/GetAllInfoEmpresa/listValues
        [HttpGet("GetAllInfoFuncionario")]
        public ActionResult<IEnumerable<string>> GetAllInfoFuncionario()
        {
            try
            {
                return Ok(_applicationServiceFuncionario.GetAllInfoFuncionario());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GetAllInfoFuncionario. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("GetAllInfoFuncionarioById/{id}")]
        public ActionResult<string> getAllInfoFuncionarioById(int id)
        {
            try
            {
                return Ok(_applicationServiceFuncionario.getAllInfoFuncionarioById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GetAllInfoFuncionarioById");
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] FuncionarioDTO funcionarioDTO)
        {
            try
            {
                if (funcionarioDTO == null)
                    return NotFound(new { message = "Funcionário inválido!" });

                _applicationServiceFuncionario.Add(funcionarioDTO);
                return Ok("Funcionário Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método POST {ex.Message}");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody] FuncionarioDTO funcionarioDTO)
        {
            try
            {
                if (funcionarioDTO == null)
                    return NotFound(new { message = "Funcionário inválidos!" });

                _applicationServiceFuncionario.Update(funcionarioDTO);
                return Ok("Funcionário Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult Delete([FromBody] FuncionarioDTO funcionarioDTO)
        {
            try
            {
                if (funcionarioDTO == null)
                    return NotFound(new { message = "Funcionário inválidos!" });

                _applicationServiceFuncionario.Remove(funcionarioDTO);
                return Ok("Funcionário Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}