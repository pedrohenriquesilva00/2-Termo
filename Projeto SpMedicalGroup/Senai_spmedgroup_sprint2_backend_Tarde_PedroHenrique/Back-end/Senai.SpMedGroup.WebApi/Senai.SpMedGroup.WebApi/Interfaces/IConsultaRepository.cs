using Senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface IConsultaRepository
    {
        /// <summary>
        /// Lista todas as Consultas
        /// </summary>
        /// <returns> Uma lista de Consultas </returns>
        List<Consulta> Listar();

        /// <summary>
        /// Lista uma consulta pelo ID
        /// </summary>
        /// <param name="id"> ID da Consulta que será buscada </param>
        /// <returns> Consulta buscada </returns>
        Consulta BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova Consulta
        /// </summary>
        /// <param name="novaConsulta"> Objeto com as informações de cadastro </param>
        void Cadastrar(Consulta novaConsulta);

        /// <summary>
        /// Atualiza uma Consulta existente
        /// </summary>
        /// <param name="id"> ID da Consulta que será atualizada </param>
        /// <param name="consultaAtualizada"> Objeto com as novas informações </param>
        void Atualizar(int id, Consulta consultaAtualizada);

        /// <summary>
        /// Deleta uma Consulta existente
        /// </summary>
        /// <param name="id"> ID da Consulta que será deletada </param>
        void Deletar(int id);

        //TODO: Opção de agendar uma consulta

        //TODO: Situação da Consulta
    }
}
