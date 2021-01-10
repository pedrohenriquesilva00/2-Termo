using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    [Table("Jogos")]
    public class Jogos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdJogo { get; set; }

        [Column(TypeName = "VARCHAR (255)")]
        [Required(ErrorMessage = "O Nome do Jogo é obrigatório!")]
        public string NomeJogo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A Descrição do jogo é obrigatória!")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime DataLancamento { get; set; }

        [Column("Preco", TypeName = "DECIMAL (18,2)")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "É necessário informar o Estúdio que produziu o Jogo!")]
        public int IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public Estudios Estudio { get; set; }
    }
}
