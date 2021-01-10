using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.WebApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Situacao { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }

        public Medico IdMedicoNavigation { get; set; }
        public Paciente IdPacienteNavigation { get; set; }
    }
}
