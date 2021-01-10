using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista os Usuários cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de Usuário</returns>
        List<UsuarioDomain> Listar();

        /// <summary>
        /// Cadastra um novo Usuário
        /// </summary>
        /// <param name="novoUsuario">Objeto Usuário que será cadastrado</param>
        void Cadastrar(UsuarioDomain novoUsuario);

        /// <summary>
        /// Busca um Usuário pelo seu ID
        /// </summary>
        /// <returns>Retorna o ID do Usuário Buscado</returns>
        UsuarioDomain BuscarPorId(int id);

        void Atualizar(int id, UsuarioDomain usuarioAtualizado);

        void Deletar(int id);

        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
