using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    /// <summary>
    /// Repositório responsável pelos Médicos
    /// </summary>
    public class MedicoRepository : IMedicoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int id, Medico medicoAtualizado)
        {
            throw new NotImplementedException();
        }

        public Medico BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastra um novo Médico
        /// </summary>
        /// <param name="novoMedico"> Objeto com as informações de cadastro </param>
        public void Cadastrar(Medico novoMedico)
        {
            // Adiciona um novo Médico
            ctx.Medico.Add(novoMedico);

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Médico existente
        /// </summary>
        /// <param name="id"> ID do Médico que será deletado </param>
        public void Deletar(int id)
        {
            // Deleta um Médico
            ctx.Medico.Remove(BuscarPorId(id));

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Médicos
        /// </summary>
        /// <returns> Uma lista de Médicos </returns>
        public List<Medico> Listar()
        {
            // Retorna uma lista com todas as informações dos Médicos
            return ctx.Medico.ToList();
        }
    }
}
