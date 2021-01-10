using Senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface IMedicoRepository
    {
        /// <summary>
        /// Lista todos os Médicos
        /// </summary>
        /// <returns> Uma lista de Médicos </returns>
        List<Medico> Listar();

        /// <summary>
        /// Lista um Médico pelo ID
        /// </summary>
        /// <param name="id"> ID do Médico que será buscado </param>
        /// <returns> Médico buscado</returns>
        Medico BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Médico
        /// </summary>
        /// <param name="novoMedico"> Objeto com as informações de cadastro </param>
        void Cadastrar(Medico novoMedico);

        /// <summary>
        /// Atualiza um Médico existente
        /// </summary>
        /// <param name="id"> ID do Médico que será atualizado </param>
        /// <param name="medicoAtualizado"> Objeto com as novas informações </param>
        void Atualizar(int id, Medico medicoAtualizado);

        /// <summary>
        /// Deleta um Médico existente
        /// </summary>
        /// <param name="id"> ID do Médico que será deletado </param>
        void Deletar(int id);
    }
}
