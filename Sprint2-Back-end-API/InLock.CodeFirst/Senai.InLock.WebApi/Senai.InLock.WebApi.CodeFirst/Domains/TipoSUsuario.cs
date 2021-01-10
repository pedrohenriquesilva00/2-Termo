using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    [Table("TiposUsuario")]
    public class TiposUsuario
    {
        // Define que é uma chave Primária
        [Key]
        // Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoUsuario { get; set; }

        // Define o tipo de coluna
        [Column(TypeName = "VARCHAR(255)")]
        // Define o Titulo como NOT NULL
        [Required(ErrorMessage = "O Titulo é obrigatório!")]
        public string Titulo { get; set; }
    }
}
