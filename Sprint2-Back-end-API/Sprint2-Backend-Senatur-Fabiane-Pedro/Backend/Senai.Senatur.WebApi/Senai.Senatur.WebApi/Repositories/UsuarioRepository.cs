using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SenaturContext ctx = new SenaturContext();

        public void Cadastrar(Usuarios novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public List<Usuarios> Listar()
        {
            return ctx.Usuarios.Include(u => u.IdTipoUsuarioNavigation).ToList();
        }

        public Usuarios BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Deletar(int id)
        {
           Usuarios  UsuarioBuscado = ctx.Usuarios.Find(id);
            ctx.Usuarios.Remove(UsuarioBuscado);
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Usuarios UsuarioAtualizado)
        {
            Usuarios usuarioBuscado = ctx.Usuarios.Find(id);

            usuarioBuscado.Email = UsuarioAtualizado.Email;
            usuarioBuscado.Senha = UsuarioAtualizado.Senha;
            usuarioBuscado.IdTipoUsuario = UsuarioAtualizado.IdTipoUsuario;

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<TiposUsuario> ListarPacotes()
        {
            return ctx.TiposUsuario.ToList();
        }

        public Usuarios BuscarPorEmailSenha(string email, string senha)
        {
            Usuarios usuarioLogado = ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
            return usuarioLogado;
        }
    }
}
