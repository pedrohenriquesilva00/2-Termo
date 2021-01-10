using Senai.SpMedGroup.WebApi.Domains;
using Senai.SpMedGroup.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Repositories
{
    /// <summary>
    /// Repositório responsável pelas Clínicas
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework Core
        /// </summary>
        SpMedGroupContext ctx = new SpMedGroupContext();

        /// <summary>
        /// Lista todas as Clínicas
        /// </summary>
        /// <param name="id"> ID da Clínica que será buscada </param>
        /// <param name="clinicaAtualizada"> Objeto com as novas informações </param>
        public void Atualizar(int id, Clinica clinicaAtualizada)
        {
            // Busca uma Clínica pelo ID
            Clinica clinicaBuscada = ctx.Clinica.Find(id);

            // Verifica se a Clínica foi encontrada
            if (clinicaBuscada != null)
            {
                // Verifica se foi informado um novo CNPJ da Clínica
                if (clinicaAtualizada.Cnpj != null)
                {
                    // Atribui o novo valor ao campo
                    clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;
                }

                // Verifica se foi informado um novo NOME para a Clínica
                if (clinicaAtualizada.NomeClinica != null)
                {
                    // Atribui o novo valor ao campo
                    clinicaAtualizada.NomeClinica = clinicaAtualizada.NomeClinica;
                }

                // Verifica se foi informado um novo ENDEREÇO
                if (clinicaAtualizada.Endereco != null)
                {
                    // Atribui o novo valor ao campo
                    clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
                }

                // Verifica se foi informado uma nova RAZÂO SOCIAL
                if (clinicaAtualizada.RazaoSocial != null)
                {
                    // Atribui o novo ao campo
                    clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
                }
            }
        }

        /// <summary>
        /// Lista uma Clínica pelo ID
        /// </summary>
        /// <param name="id"> ID da Clínica que será buscada </param>
        /// <returns> Clínica buscada </returns>
        public Clinica BuscarPorId(int id)
        {
            // Busca a primeira Clínica para o ID informado e armazena no objeto clinicaBuscada
            Clinica clinicaBuscada = ctx.Clinica.FirstOrDefault(c => c.IdClinica == id);

            // Verifica se a Clínica foi encontrada
            if (clinicaBuscada != null)
            {
                // Retorna a Clínica encontrada
                return clinicaBuscada;
            }

            // Caso não seja encontrada, retorna nulo
            return null;
        }

        /// <summary>
        /// Cadastra uma nova Clínica
        /// </summary>
        /// <param name="novaClinica"> Objeto com as informações de cadastro </param>
        public void Cadastrar(Clinica novaClinica)
        {
            //Adiciona uma nova Clínica
            ctx.Clinica.Add(novaClinica);

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma Clínica existente
        /// </summary>
        /// <param name="id"> ID da Clínica que será deletado </param>
        public void Deletar(int id)
        {
            // Remove a Clínica que foi buscada através do ID
            ctx.Clinica.Remove(BuscarPorId(id));

            // Salva as informações para serem gravadas no Banco de Dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todas as Clínicas
        /// </summary>
        /// <returns> Uma lista com as informações das Clínicas </returns>
        public List<Clinica> Listar()
        {
            // Retorna uma lista com todas as informações das Clínicas
            return ctx.Clinica.ToList();
        }
    }
}
