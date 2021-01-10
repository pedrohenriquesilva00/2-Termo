using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        [Authorize(Roles = "1,2")]
        public List<Usuarios> Get()
        {
            return _usuarioRepository.Listar();
        }

        /// <summary>
        /// Busca um usuário através do ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Um usuário buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetById(int id)
        {
            return Ok(_usuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Usuarios novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="id">ID do usuário que será deletado</param>
        /// <returns>Um um status code 200 - Ok - No Content</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar();
            _usuarioRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("Usuario deletado");
        }

    }
}