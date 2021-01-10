using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Route("api/[controller]")]

    // Defini que a resposta da Api será no formato Json
    [Produces("application/json")]

    [ApiController]

    //[Authorize]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        [HttpGet]
        [Authorize(Roles = "1 , 2")]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            if(novoUsuario.Email == null)
            {
                return BadRequest("O email é de campo obrigatório");
            }

            _usuarioRepository.Cadastrar(novoUsuario);

            return Created("http://localhost:5000/api/Usuarios", novoUsuario);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetByid(int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if(usuarioBuscado != null)
            {
                return Ok(usuarioBuscado);
            }
            return NotFound("Nenhum Usuário encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Put(int id, UsuarioDomain usuarioAtualizado)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if(usuarioBuscado != null)
            {
                try
                {
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);
                    return NoContent();
                }
                catch(Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                (
                    new
                    {
                        mensagem = "Usuário não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);
            
            if(usuarioBuscado != null)
            {
                _usuarioRepository.Deletar(id);

                return Ok($"O usuário {id} foi deletado com sucesso!");
            }
            return NotFound("Nenhum usuário encontrado para o identificador informado");
        }
    }
}