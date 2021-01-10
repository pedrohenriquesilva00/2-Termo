using Senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// Lista todos os Tipos de Usuários
        /// </summary>
        /// <returns> Uma lista de Tipos de Usuários</returns>
        List<TipoUsuario> Listar();

        /// <summary>
        /// Lista um Tipo de Usuário pelo ID
        /// </summary>
        /// <param name="id"> ID do Tipo de Usuário que será buscado </param>
        /// <returns> Tipo de Usuário buscado </returns>
        TipoUsuario BuscaPorId(int id);

        /// <summary>
        /// Cadastra um Tipo de Usuário
        /// </summary>
        /// <param name="novoTipoUsuario"> Objeto com as informações de cadastro </param>
        void Cadastrar(TipoUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um Tipo de Usuário existente
        /// </summary>
        /// <param name="id"> ID do Tipo de Usuário que será atualizado </param>
        /// <param name="tipoUsuarioAtualizado"> Objeto com as novas informações </param>
        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um Tipo de Usuário existente
        /// </summary>
        /// <param name="id"> ID do Tipo de Usuário que será deletado </param>
        void Deletar(int id);
    }
}
