using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApiCheckApp.Application.DTO.DTO;
using webApiCheckApp.Application.DTO.DTO.DTOHelpers;
using WebApiCheckApp.Application.Interfaces;

namespace WebApiCheckApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IApplicationServiceUsuario _applicationServiceUsuario;

        public UsuarioController(IApplicationServiceUsuario applicationServiceUsuario)
        {
            _applicationServiceUsuario = applicationServiceUsuario;
        }

        // GET api/listValues
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {
                return Ok(_applicationServiceUsuario.GetAllUsuario());
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
                return Ok(_applicationServiceUsuario.GetById(id));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método GETBYID");
            }

        }

        // POST api/recuperarSenha/values
        [HttpPost("recuperarSenha")]
        public ActionResult recuperarSenha([FromQuery] string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return NotFound(new { message = "Email inválido!" });

                return Ok(_applicationServiceUsuario.ResetSenhaUsuario(email));
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método Login");
            }
        }

        // POST api/recuperarSenha/values
        [HttpPost("alterarSenha")]
        [Authorize]
        public ActionResult alterarSenha([FromBody] ModeloAlterarSenhaUserDTO modeloAlterarSenhaUserDTO)
        {
            try
            {
                if (modeloAlterarSenhaUserDTO == null)
                    return NotFound(new { message = "Usuário inválido!" });

                _applicationServiceUsuario.AlterarSenhaUsuario(modeloAlterarSenhaUserDTO);

                return Ok("Senha Alterada com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método Login");
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound(new { message = "Usuário inválidos!" });

                _applicationServiceUsuario.Add(usuarioDTO);
                return Ok("Usuário Cadastrado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método POST");
            }
        }

        // POST api/Login/values
        [HttpPost("Login")]
        public ActionResult Login([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound(new { message = "Usuário inválido!" });

                return Ok(_applicationServiceUsuario.GetUserByUserAndPass(usuarioDTO));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método Login");
            }
        }

        // PUT api/values/obj
        [HttpPut]
        public ActionResult Put([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound(new { message = "Usuário inválidos!" });

                _applicationServiceUsuario.Update(usuarioDTO);
                return Ok("Usuário Atualizado com sucesso!");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método PUT");
            }
        }

        // DELETE api/values/obj
        [HttpDelete]
        public ActionResult Delete([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (usuarioDTO == null)
                    return NotFound(new { message = "Usuário inválidos!" });

                _applicationServiceUsuario.Remove(usuarioDTO);
                return Ok("Usuário Removido com sucesso!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados Falhou - método DELETE");
            }

        }
    }
}