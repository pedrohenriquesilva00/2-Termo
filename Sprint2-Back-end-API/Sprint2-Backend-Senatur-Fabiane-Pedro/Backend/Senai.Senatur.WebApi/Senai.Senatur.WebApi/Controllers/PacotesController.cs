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
    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacoteRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public PacotesController()
        {
            _pacoteRepository = new PacoteRepository();
        }

        /// <summary>
        /// Listar todos os  Pacotes
        /// </summary>
        /// <returns>Uma lista de Pacotes </returns>
        [HttpGet]
        [Authorize(Roles = "1,2")]
        public List<Pacotes> Get()
        {
            return _pacoteRepository.Listar();
        }

        /// <summary>
        /// Busca um Pacote através do ID
        /// </summary>
        /// <param name="id">ID do Pacote que será buscado</param>
        /// <returns>Um tipo de usuário buscado e um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult GetById(int id)
        {
            return Ok(_pacoteRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Listar todos os pacotes de maneira ordenada
        /// </summary>
        /// <param name="ordem">string que define a ordenação(crescente ou decrescente</param>
        /// <returns>Retona uma lista ordenada de pacotes</returns>
        [HttpGet("Ordenacao/{ordem}")]
        [Authorize(Roles = "1")]
        public IActionResult GetOrderBy(string ordem)
        {
            //Verificar se a ordenação atende aos requisitos
            if (ordem != "ASC" && ordem != "DESC")
            {
                //Caso não, retorna um status code 404 - BadRequest com uma mensagem de erro
                return BadRequest("Não é possivel ordenar os pacotes.Por favor ordene por 'ASC' ou 'DESC'");
            }
            // Retorna a lista ordenada com um status code 200 - OK
            return Ok(_pacoteRepository.ListarOrdenado(ordem));
        }

        /// <summary>
        /// Lista os pacotes ativos e inativos
        /// </summary>
        /// <param name="pacotesAtivos">objeto pacotesAtivos que será buscado</param>
        /// <returns>retorna os pacotes ativos ou inativos</returns>
        [HttpGet("Ativos/{pacotesAtivos}")]
        public IActionResult PacotesAtivos(bool pacotesAtivos)
        {
            return Ok(_pacoteRepository.ListarPorAtivo(pacotesAtivos));
        }

        /// <summary>
        /// Lista um pacote de acordo com a Cidade
        /// </summary>
        /// <param name="cidade">Objeto cidade que será buscado</param>
        /// <returns>Retorna um pacote de uma cidade especifica</returns>
        [HttpGet("Cidades/{cidade}")]
        public IActionResult PacotesCidades(string cidade)
        {
            return Ok(_pacoteRepository.ListarPorCidade(cidade));
        }

        /// <summary>
        /// Cadastra um novo Pacote
        /// </summary>
        /// <param name="novoPacote">Objeto com as informações</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        [Authorize(Roles = "1")]
        public IActionResult Post(Pacotes novoPacote)
        {
            // Faz a chamada para o método
            _pacoteRepository.Cadastrar(novoPacote);

            // Retorna um status code
            return StatusCode(201);
        }

        /// <summary>
        /// Deleta um Pacote
        /// </summary>
        /// <param name="id">ID do pacote que será deletado</param>
        /// <returns>status code</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar();
            _pacoteRepository.Deletar(id);

            // Retorna um status code com uma mensagem personalizada
            return Ok($"Pacote {id} deletado");
        }

        /// <summary>
        /// Atualiza um Pacote pelo ID
        /// </summary>
        /// <param name="id">ID do pacote que será atualizado</param>
        /// <param name="pacoteAtualizado"></param>
        /// <returns>Retorna o Pacote alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes pacoteAtualizado)
        {
            // Faz a chamada para o método
            _pacoteRepository.Atualizar(id, pacoteAtualizado);

            // Retorna um status code
            return StatusCode(204);
        }
    }
}