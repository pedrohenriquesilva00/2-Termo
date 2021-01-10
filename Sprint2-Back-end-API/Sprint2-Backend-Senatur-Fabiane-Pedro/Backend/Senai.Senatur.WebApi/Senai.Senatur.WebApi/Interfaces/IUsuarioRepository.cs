using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Senatur.WebApi.Domains;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();

        Usuarios BuscarPorId(int id);

        void Cadastrar(Usuarios novoUsuario);

        void Atualizar(int id, Usuarios usuarioAtualizado);

        void Deletar(int id);

        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
