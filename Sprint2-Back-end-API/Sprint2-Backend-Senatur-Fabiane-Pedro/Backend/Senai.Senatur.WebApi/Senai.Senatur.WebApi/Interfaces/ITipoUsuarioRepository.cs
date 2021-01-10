using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Senatur.WebApi.Domains;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        
        TiposUsuario BuscarPorId(int id);

        void Cadastrar(TiposUsuario novotipoUsuario);

        void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado);

        void Deletar(int id);

        List<TiposUsuario> Listar();
    }
}
