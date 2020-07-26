using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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
        [HttpGet("getAllInfoEmpresaClienteById/{id}")]
        public ActionResult<string> getAllInfoEmpresaClienteById(int id)
        {
            try
            {
                return Ok(_applicationServiceEmpresaCliente.getAllInfoEmpresaClienteById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
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

        // GET  api/getAllEquipamentoByIdAndTipo?id=1&tipoId=2
        [HttpGet("getAllEquipamentoByIdAndTipo")]
        public ActionResult<string> getAllEquipamentoByIdAndTipo([FromQuery] int id, [FromQuery] int tipoId)
        {
            try
            {
                return Ok(_applicationServiceEmpresaCliente.getAllEquipamentoByIdAndTipo(id, tipoId));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // GET  api/getRelatOcorrenciaForEmp
        [HttpGet("getRelatOcorrenciaForEmp")]
        public ActionResult<string> getRelatOcorrenciaForEmp()
        {
            try
            {
                return Ok(_applicationServiceEmpresaCliente.getRelatOcorrenciaForEmp());
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETRELATOCORRENCIAFOREMP" + ex.Message);
            }

        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] EmpresaClienteDTO empresaClienteDTO)
        {
            try
            {
                if (empresaClienteDTO == null)
                    return NotFound(new { message = "Empresa inválida!" });

                _applicationServiceEmpresaCliente.Add(empresaClienteDTO);
                return Ok("Empresa Cadastrada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        // POST api/values
        [HttpPost("upload")]
        public ActionResult upload()
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName;
                    var fullPath = Path.Combine(pathToSave, fileName.Replace("\"", " ").Trim());

                    if (System.IO.File.Exists(fullPath))
                        return Ok();

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - UPLOADIMG POST");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody] EmpresaClienteDTO empresaClienteDTO)
        {
            try
            {
                if (empresaClienteDTO == null)
                    return NotFound(new { message = "Empresa inválida!" });

                _applicationServiceEmpresaCliente.Update(empresaClienteDTO);
                return Ok("Empresa Atualizada com sucesso!");
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
                    return NotFound(new { message = "Empresa inválida!" });

                _applicationServiceEmpresaCliente.Remove(empresaClienteDTO);
                return Ok("Empresa Removida com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }

    }
}