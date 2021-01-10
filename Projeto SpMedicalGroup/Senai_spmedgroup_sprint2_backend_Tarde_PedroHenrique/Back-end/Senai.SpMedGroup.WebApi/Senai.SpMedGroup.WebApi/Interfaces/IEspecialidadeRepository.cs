using Senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        /// <summary>
        /// Lista todas as Especialidades
        /// </summary>
        /// <returns> Uma lista de Especialidades </returns>
        List<Especialidade> Listar();

        /// <summary>
        /// Busca uma Especialidade pelo ID
        /// </summary>
        /// <param name="id"> ID da Especialidade que será buscada </param>
        /// <returns> Especialidade buscada </returns>
        Especialidade BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova Especialidade
        /// </summary>
        /// <param name="novaEspecialidade"> Objeto com as informações de cadastro </param>
        void Cadastrar(Especialidade novaEspecialidade);

        /// <summary>
        /// Atualiza uma Especialidade existente
        /// </summary>
        /// <param name="id"> ID da Especialidade que será atualizada </param>
        /// <param name="especialidadeAtualizada"> Objeto com as novas informações </param>
        void Atualizar(int id, Especialidade especialidadeAtualizada);

        /// <summary>
        /// Deleta uma Especialidade existente
        /// </summary>
        /// <param name="id"> ID da Especialidade que será deletada </param>
        void Deletar(int id);
    }
}
