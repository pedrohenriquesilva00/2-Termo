using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    /// <summary>
    /// Repositório responsável pelas Especialidades
    /// </summary>
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core 
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza uma Especialidade existente
        /// </summary>
        /// <param name="id"> ID da Especialidade que será atualizada </param>
        /// <param name="especialidadeAtualizada"> Objeto com as novas informações </param>
        public void Atualizar(int id, Especialidade especialidadeAtualizada)
        {
            // Busca uma especialida pelo ID
            Especialidade especialidadeBuscada = ctx.Especialidade.Find(id);

            // Verifica se a Especialidade foi encontrada
            if (especialidadeBuscada != null)
            {
                // Verifica se foi informado um nome de Especialidade
                if (especialidadeAtualizada.Nome != null)
                {
                    // Atribui o novo valor ao campo
                    especialidadeBuscada.Nome = especialidadeAtualizada.Nome;
                }

                // Atualiza o Nome da Especialidade que foi buscada
                ctx.Especialidade.Update(especialidadeBuscada);

                // Salva as informações para serem gravadas no banco
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista uma Especialidade pelo ID
        /// </summary>
        /// <param name="id"> ID da Especialidade que será buscada </param>
        /// <returns> Especialidade buscada </returns>
        public Especialidade BuscarPorId(int id)
        {
            // Busca a primeira Especialidade encontrada para o ID informado e armazena no objeto especialidadeBuscada
            Especialidade especialidadeBuscada = ctx.Especialidade.FirstOrDefault(e => e.IdEspecialidade == id);

            // Verifica se a Especialidade foi encontrada
            if (especialidadeBuscada != null)
            {
                // Retorna a Especialidade encontrada
                return especialidadeBuscada;
            }

            // Caso não seja encontrada, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra uma nova Especialidade
        /// </summary>
        /// <param name="novaEspecialidade"> Objeto com as informações de cadastro </param>
        public void Cadastrar(Especialidade novaEspecialidade)
        {
            // Adiciona uma nova Especialidade
            ctx.Especialidade.Add(novaEspecialidade);

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Especialidade existente
        /// </summary>
        /// <param name="id"> ID da Especialidade que será deletada </param>
        public void Deletar(int id)
        {
            // Remove a Especialidade que foi buscada através do ID informado
            ctx.Especialidade.Remove(BuscarPorId(id));

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as Especialidades
        /// </summary>
        /// <returns> Uma lista com todas as Especialidades</returns>
        public List<Especialidade> Listar()
        {
            // Retorna uma lista com todas as informações das Especialidades
            return ctx.Especialidade.ToList();
        }
    }
}
