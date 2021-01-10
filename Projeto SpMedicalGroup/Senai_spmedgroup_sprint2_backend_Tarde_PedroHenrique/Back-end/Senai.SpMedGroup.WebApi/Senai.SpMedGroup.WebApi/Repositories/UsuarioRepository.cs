using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    /// <summary>
    /// Repositório responsável pelos Usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Atualiza um Usuário existente
        /// </summary>
        /// <param name="id"> ID do Usuário que será buscado </param>
        /// <param name="usuarioAtualizado"> Objeto com as novas informações </param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            // Busca um Usuário através do ID
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            // Verifica se o Usuário foi encontrado
            if (usuarioAtualizado != null)
            {
                // Verifica se foi informado um NOME de USUÁRIO
                if (usuarioAtualizado.NomeUsuario != null)
                {
                    // Atribui o valor ao campo
                    usuarioBuscado.NomeUsuario = usuarioAtualizado.NomeUsuario;
                }

                // Verifica se foi informado um EMAIL
                if (usuarioAtualizado.Email != null)
                {
                    // Atribui o valor ao campo
                    usuarioBuscado.Email = usuarioAtualizado.Email;
                }

                // Verifica se foi informada uma SENHA
                if (usuarioAtualizado.Senha != null)
                {
                    usuarioBuscado.Senha = usuarioAtualizado.Senha;
                }

                // Verifica se foi informado um TIPO de USUÁRIO
                if (usuarioAtualizado.IdTipoUsuario != null)
                {
                    // Atribui o valor ao campo
                    usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
                }
            }
        }

        public Usuario BuscarPorId(int id)
        {
            // Método sem mostrar a senha ao listar as informações do Usuário
            Usuario usuarioBuscado = ctx.Usuario

                // Seleciona apenas as informações que devem ser mostradas
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    NomeUsuario = u.NomeUsuario,
                    Email = u.Email,

                    IdTipoUsuarioNavigation = new TipoUsuario
                    {
                        Titulo = u.IdTipoUsuarioNavigation.Titulo
                    }
                })

                .FirstOrDefault(u => u.IdUsuario == id);

            // Verifica se o usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuário encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra um novo Usuário
        /// </summary>
        /// <param name="novoUsuario"> Objeto com as informações de cadastro </param>
        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona um novo Usuário
            ctx.Usuario.Add(novoUsuario);

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um Usuário existente
        /// </summary>
        /// <param name="id"> ID do Usuário que será deletado </param>
        public void Deletar(int id)
        {
            // Deleta um Usuário
            ctx.Usuario.Remove(BuscarPorId(id));

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os Usuários
        /// </summary>
        /// <returns> Uma lista de Usuários </returns>
        public List<Usuario> Listar()
        {
            // Retorna uma lista com todas as informações dos Usuários
            return ctx.Usuario.ToList();
        }
    }
}
