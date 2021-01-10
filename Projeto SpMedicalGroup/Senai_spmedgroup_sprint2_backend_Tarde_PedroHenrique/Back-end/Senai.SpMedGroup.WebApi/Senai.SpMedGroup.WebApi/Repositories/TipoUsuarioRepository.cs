using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    /// <summary>
    /// Repositório responsável pelos Tipos de Usuários
    /// </summary>
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza um Tipo de Usuário existente
        /// </summary>
        /// <param name="id"> ID do Tipo de Usuário que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado"> Objeto com as novas informações </param>
        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            // Busca um Tipo de Usuário pelo iD
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(id);

            //Verifica se o Tipo de Usuário foi encontrado
            if (tipoUsuarioBuscado != null)
            {
                // Verifica se foi informado um Titulo para o Tipo de Usuário
                if (tipoUsuarioAtualizado.Titulo != null)
                {
                    // Atribui o valor ao campo
                    tipoUsuarioBuscado.Titulo = tipoUsuarioAtualizado.Titulo;
                }

                //Atualiza o nome do Tipo de Usuário que foi buscado
                ctx.TipoUsuario.Update(tipoUsuarioBuscado);

                // Salva as informações para serem gravadas no Banco de Dados
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista um Tipo de Usuário pelo ID
        /// </summary>
        /// <param name="id"> ID do Tipo de Usuário que será buscado </param>
        /// <returns> Tipo de Usuário buscado </returns>
        public TipoUsuario BuscaPorId(int id)
        {
            // Busca o primeiro Tipo de Usuário encontrado para o ID informado e armazena no objeto tipoUsuarioBuscado
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.FirstOrDefault(tu => tu.IdTipoUsuario == id);
            
            // Verifica se o Tipo de Usuário foi encontrado
            if (tipoUsuarioBuscado != null)
            {
                // Retorna o Tipo de Usuário encontrado
                return tipoUsuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo Tipo de Usuário
        /// </summary>
        /// <param name="novoTipoUsuario"> Objeto com as informações de cadastro </param>
        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            // Adiciona um novo Tipo de Usuário
            ctx.TipoUsuario.Add(novoTipoUsuario);

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Tipo de Usuário existente
        /// </summary>
        /// <param name="id"> ID do Tipo de Usuário que será deletado </param>
        public void Deletar(int id)
        {
            // Remove o Tipo de Usuário que foi buscado através do ID
            ctx.TipoUsuario.Remove(BuscaPorId(id));

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Tipos de Usuários
        /// </summary>
        /// <returns> Uma lista com todos os Tipos de Usuários </returns>
        public List<TipoUsuario> Listar()
        {
            // Retorna uma lista com todas as informações dos Tipos de Usuários
            return ctx.TipoUsuario.ToList();
        }
    }
}
