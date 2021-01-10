using Senai.Peoples.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        /// <summary>
        /// LIsta os tipos de usuario
        /// </summary>
        /// <returns>Retorna uma lista de Tipos de usuarios</returns>
        List<TipoUsuarioDomain> Listar();

        /// <summary>
        /// Busca um tipo de usuario pelo seu ID
        /// </summary>
        /// <param name="id">Id do TipoUsuario que será buscado</param>
        /// <returns>Retorna o Id Buscado</returns>
        TipoUsuarioDomain BuscarPorId(int id);

        /// <summary>
        /// Atualiza um tipo existente
        /// </summary>
        /// <param name="id">id do tipo que será atualizado</param>
        /// <param name="tipoUsuarioAtualizado">Objeto TipoUsuario que será atualizado</param>
        void Atualizar(int id, TipoUsuarioDomain tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um TipoUsuario existente
        /// </summary>
        /// <param name="id">Id do TipoUsuario que será deletado</param>
        void Deletar(int id);
    }
}
