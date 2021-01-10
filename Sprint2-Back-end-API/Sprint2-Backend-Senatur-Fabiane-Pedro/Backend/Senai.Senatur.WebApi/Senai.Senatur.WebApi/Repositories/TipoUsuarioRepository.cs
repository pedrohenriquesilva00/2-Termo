using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository

    {
        SenaturContext ctx = new SenaturContext();

        public void Cadastrar(TiposUsuario novoTipoUsuario)
        {
            ctx.TiposUsuario.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuario.ToList();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Deletar(int id)
        {
            TiposUsuario tiposUsuarioBuscado = ctx.TiposUsuario.Find(id);
            ctx.TiposUsuario.Remove(tiposUsuarioBuscado);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, TiposUsuario  TipoUsuarioAtualizado)
        {
          TiposUsuario tipousuarioBuscado = ctx.TiposUsuario.Find(id);

            tipousuarioBuscado.Titulo = TipoUsuarioAtualizado.Titulo;

            ctx.TiposUsuario.Update(tipousuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> ListarPacotes()
        {
            return ctx.TiposUsuario.ToList();
        }
    }
}
