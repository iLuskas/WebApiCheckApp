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

namespace WebApiCheckApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspecaoController : ControllerBase
    {
        private readonly IApplicationServiceInspecao _applicationServiceInspecao;

        public InspecaoController(IApplicationServiceInspecao applicationServiceInspecao)
        {
            _applicationServiceInspecao = applicationServiceInspecao;
        }

        // GET api/listValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_applicationServiceInspecao.GetAll());
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
                return Ok(_applicationServiceInspecao.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // GET api/values
        [HttpGet("GetInspecaoByEquipIdAndAgeId")]
        public ActionResult<string> GetInspecaoByEquipIdAndAgeId([FromQuery] int equipamentoId, int agendamentoId)
        {
            try
            {
                return Ok(_applicationServiceInspecao.GetInspecaoByEquipIdAndAgeId(equipamentoId, agendamentoId));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco de dados Falhou - método GETINSPECAOBYEQUIPIDANDAGEID. {ex.Message}");
            }
        }


        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] InspecaoDTO inspecaoDTO)
        {
            try
            {
                if (inspecaoDTO == null)
                    return NotFound(new { message = "Dados da Inspeção inválido!" });

                _applicationServiceInspecao.Add(inspecaoDTO);
                return Ok("Inspeção Cadastrada com sucesso!");
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

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método UPLOADIMG");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody]  InspecaoDTO inspecaoDTO)
        {
            try
            {
                if (inspecaoDTO == null)
                    return NotFound(new { message = "Dados da Inspeção inválidos!" });

                _applicationServiceInspecao.Update(inspecaoDTO);
                return Ok("Inspeção Atualizada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult Delete([FromBody]  InspecaoDTO inspecaoDTO)
        {
            try
            {
                if (inspecaoDTO == null)
                    return NotFound(new { message = "Dados da Inspeção inválidos!" });

                _applicationServiceInspecao.Remove(inspecaoDTO);
                return Ok("Inspeção Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}