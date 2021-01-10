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
    [Authorize(Roles = "1")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository;
        
        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        [HttpGet]
        public List<TiposUsuario> Get()
        {
            return _tipoUsuarioRepository.Listar();
        }

        /// <summary>
        /// Busca um tipo de usuário através do ID
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será buscado</param>
        /// <returns>Um tipo de usuário buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novotipoUsuario">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TiposUsuario novotipoUsuario)
        {
            // Faz a chamada para o método
            _tipoUsuarioRepository.Cadastrar(novotipoUsuario);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um tipo de usuário
        /// </summary>
        /// <param name="id">ID do tipo de usuário que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar();
            _tipoUsuarioRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok("TipoUsuario deletado");
        }
    }

}