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
    public class EmpresaClienteController : ControllerBase
    {
        private readonly IApplicationServiceEmpresaCliente _applicationServiceEmpresaCliente;

        public EmpresaClienteController(IApplicationServiceEmpresaCliente applicationServiceEmpresaCliente)
        {
            _applicationServiceEmpresaCliente = applicationServiceEmpresaCliente;
        }

        // GET api/listValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_applicationServiceEmpresaCliente.GetAll());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETALL. {ex.Message}");
            }

        }

        // GET api/GetAllInfoEmpresa/listValues
        [HttpGet("GetAllInfoEmpresa")]
        public ActionResult<IEnumerable<string>> GetAllInfoEmpresa()
        {
            try
            {
                return Ok(_applicationServiceEmpresaCliente.GetAllInfoEmpressaCliente());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GetAllInfoEmpresa. {ex.Message}");
            }

        }

        // GET  api/values/id
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(_applicationServiceEmpresaCliente.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] EmpresaClienteDTO empresaClienteDTO)
        {
            try
            {
                if (empresaClienteDTO == null)
                    return NotFound(new { message = "Usuário inválidos!" });

                _applicationServiceEmpresaCliente.Add(empresaClienteDTO);
                return Ok("Usuário Cadastrado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody] EmpresaClienteDTO empresaClienteDTO)
        {
            try
            {
                if (empresaClienteDTO == null)
                    return NotFound(new { message = "Usuário inválidos!" });

                _applicationServiceEmpresaCliente.Update(empresaClienteDTO);
                return Ok("Usuário Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult Delete([FromBody] EmpresaClienteDTO empresaClienteDTO)
        {
            try
            {
                if (empresaClienteDTO == null)
                    return NotFound(new { message = "Usuário inválidos!" });

                _applicationServiceEmpresaCliente.Remove(empresaClienteDTO);
                return Ok("Usuário Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}