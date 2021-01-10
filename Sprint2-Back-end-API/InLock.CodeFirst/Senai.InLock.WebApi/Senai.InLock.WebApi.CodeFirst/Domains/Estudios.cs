using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    [Table("Estudios")]
    public class Estudios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEstudio { get; set; }

        [Column(TypeName = "VARCHAR (255)")]
        [Required(ErrorMessage = "O Nome do Estudio é obrigatório!")]
        public string NomeEstudio { get; set; }

        public List<Jogos> Jogos { get; set;}
    }
}
