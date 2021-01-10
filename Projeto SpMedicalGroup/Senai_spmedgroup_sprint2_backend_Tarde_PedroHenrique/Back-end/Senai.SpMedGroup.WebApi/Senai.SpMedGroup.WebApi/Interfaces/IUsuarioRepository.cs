using Senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Usuários
        /// </summary>
        /// <returns> Uma lista de usuários</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Lista um Usuário pelo ID
        /// </summary>
        /// <param name="id"> ID do Usuário que será buscado </param>
        /// <returns> Usuário buscado </returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Usuário
        /// </summary>
        /// <param name="novoUsuario"> Objeto com as informações de cadastro </param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um Usuário existente
        /// </summary>
        /// <param name="id"> ID do Usuário que será atualizado </param>
        /// <param name="usuarioAtualizado"> Objeto com as novas informações </param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um Usuário existente
        /// </summary>
        /// <param name="id"> ID do Usuário que será deletado </param>
        void Deletar(int id);
    }
}
