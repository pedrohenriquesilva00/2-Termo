using Senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface IClinicaRepository
    {
        /// <summary>
        /// Lista todas as Clínicas
        /// </summary>
        /// <returns> Uma lista de clínicas </returns>
        List<Clinica> Listar();

        /// <summary>
        /// Lista uma Clínica pelo ID
        /// </summary>
        /// <param name="id"> ID da Clínica que será buscada </param>
        /// <returns> Clínica buscada </returns>
        Clinica BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova Clínica
        /// </summary>
        /// <param name="novaClinica"> Objeto com as informações de cadastro </param>
        void Cadastrar(Clinica novaClinica);

        /// <summary>
        /// Atualiza uma Clínica existente
        /// </summary>
        /// <param name="id"> ID da Clínica que será atualizada </param>
        /// <param name="clinicaAtualizada"> Objeto com as novas informações </param>
        void Atualizar(int id, Clinica clinicaAtualizada);
        
        /// <summary>
        /// Deleta uma Clínica existente
        /// </summary>
        /// <param name="id"> ID da Clínica que será deletada </param>
        void Deletar(int id);
    }
}
