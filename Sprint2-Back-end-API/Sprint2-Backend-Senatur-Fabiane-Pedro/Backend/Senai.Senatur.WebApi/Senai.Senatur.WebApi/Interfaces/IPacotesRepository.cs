using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Senatur.WebApi.Controllers;
using Senai.Senatur.WebApi.Domains;

namespace Senai.Senatur.WebApi.Interfaces
{
    interface IPacotesRepository
    {
        List<Pacotes> Listar();

        Pacotes BuscarPorId(int id);

        void Cadastrar(Pacotes novoPacote);

        void Deletar(int id);

        void Atualizar(int id, Pacotes pacoteAtualizado);

        List<Pacotes> ListarOrdenado(string ordem);

        List<Pacotes> ListarPorAtivo(bool pacotesAtivos);

        List<Pacotes> ListarPorCidade(string cidade);
    }
}
