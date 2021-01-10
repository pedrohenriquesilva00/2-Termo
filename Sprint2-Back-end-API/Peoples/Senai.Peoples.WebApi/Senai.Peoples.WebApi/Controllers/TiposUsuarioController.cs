using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    [Authorize(Roles = "1")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TiposUsuarioController()
        {
            _tipoUsuarioRepository = new TiposUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if(tipoUsuarioBuscado != null)
            {
                return Ok(tipoUsuarioBuscado);
            }
            return NotFound("Nenhum Tipo de Usuário encontrado para o identificador informado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            if(tipoUsuarioBuscado != null)
            {
                try
                {
                    _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                (
                    new
                    {
                        mensagem = "Tipo de Usuário não encontrado",
                        erro = true
                    }
                );
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

            // Verifica se o funcionário foi encontrado
            if (tipoUsuarioBuscado != null)
            {
                // Caso seja, faz a chamada para o método .Deletar()
                _tipoUsuarioRepository.Deletar(id);

                // e retorna um status code 200 - Ok com uma mensagem de sucesso
                return Ok($"O Tipo de Usuário {id} foi deletado com sucesso!");
            }

            // Caso não seja, retorna um status code 404 - NotFound com a mensagem
            return NotFound("Nenhum Tipo de Usuário encontrado para o identificador informado");
        }
    }
}