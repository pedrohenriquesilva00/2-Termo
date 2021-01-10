using Senai.SpMedGroup.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.WebApi.Interfaces
{
    interface IPacienteRepository
    {
        /// <summary>
        /// Lista todos os Pacientes
        /// </summary>
        /// <returns> Uma lista de Pacientes</returns>
        List<Paciente> Listar();

        /// <summary>
        /// Lista um Paciente pelo ID
        /// </summary>
        /// <param name="id"> ID do Paciente que será buscado</param>
        /// <returns> Paciente buscado </returns>
        Paciente BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Paciente
        /// </summary>
        /// <param name="novoPaciente"> Objeto com as informações de cadastro </param>
        void Cadastrar(Paciente novoPaciente);

        /// <summary>
        /// Atualiza um Paciente existente
        /// </summary>
        /// <param name="id"> ID do Paciente que será atualizado </param>
        /// <param name="pacienteAtualizado"> Objeto com as novas informações </param>
        void Atualizar(int id, Paciente pacienteAtualizado);

        /// <summary>
        /// Deleta um Paciente existente
        /// </summary>
        /// <param name="id"> ID do Paciente que será deletado </param>
        void Deletar(int id);
    }
}
