using Microsoft.EntityFrameworkCore;
using Senai.Senatur.WebApi.Controllers;
using Senai.Senatur.WebApi.Domains;
using Senai.Senatur.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Repositories
{
    public class PacoteRepository : IPacotesRepository 
    {
        SenaturContext ctx = new SenaturContext();

        public void Cadastrar (Pacotes novopacote)
        {
            ctx.Pacotes.Add(novopacote);
            ctx.SaveChanges();
        }

        public List<Pacotes> Listar()
        {
            return ctx.Pacotes.ToList();
        }

        public Pacotes BuscarPorId(int id)
        {
            return ctx.Pacotes.FirstOrDefault(e => e.IdPacote == id);
        }

        public void Deletar (int id)
        {
            ctx.Pacotes.Remove(BuscarPorId(id));
            ctx.SaveChanges();
        }

        public void Atualizar(int id, Pacotes pacoteAtualizado)
        {
            // Busca um Pacote através do id
            Pacotes pacoteBuscado = ctx.Pacotes.Find(id);

            // Atribui os novos valores ao campos existentes
            pacoteBuscado.NomePacote = pacoteAtualizado.NomePacote;
            pacoteBuscado.Descricao = pacoteAtualizado.Descricao;
            pacoteBuscado.DataIda = pacoteAtualizado.DataIda;
            pacoteBuscado.DataVolta = pacoteAtualizado.DataVolta;
            pacoteBuscado.Valor = pacoteAtualizado.Valor;
            pacoteBuscado.Ativo = pacoteAtualizado.Ativo;
            pacoteBuscado.NomeCidade = pacoteAtualizado.NomeCidade;

            // Atualiza o Pacote que foi buscado
            ctx.Pacotes.Update(pacoteBuscado);

            // Salva as informações para serem gravadas no banco
            ctx.SaveChanges();
        }

        public List<Pacotes> ListarOrdenado(string ordem)
        {
            if (ordem == "ASC")
            {
                return ctx.Pacotes.OrderBy(p => p.Valor).ToList();
            }
            else
            {
                return ctx.Pacotes.OrderByDescending(p => p.Valor).ToList();
            }
        }

        public List<Pacotes> ListarPorAtivo(bool pacotesAtivos)
        {
            if(pacotesAtivos == true)
            {
                return ctx.Pacotes.Where(p => p.Ativo == true).ToList();
            }
            return ctx.Pacotes.Where(p => p.Ativo == false).ToList();
        }

        public List<Pacotes> ListarPorCidade(string cidade)
        {
            return ctx.Pacotes.Where(p => p.NomeCidade.Contains(cidade)).ToList();
        }
    }
}
