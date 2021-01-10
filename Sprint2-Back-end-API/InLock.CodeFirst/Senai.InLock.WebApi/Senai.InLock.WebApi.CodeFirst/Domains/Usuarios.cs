using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR (255)")]
        [Required(ErrorMessage = "O Email é obrigatório!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR (255)")]
        [Required(ErrorMessage = "A Senha é obrigatória!")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength =  5, ErrorMessage = "A Senha deve conter o número de caracteres informado!")]
        public string Senha  { get; set; }

        public int IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario TipoUsuario { get; set; }
    }
}
