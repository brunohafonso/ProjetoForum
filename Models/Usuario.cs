using System;
using System.ComponentModel.DataAnnotations;

namespace projetoForum.Models
{
    public class Usuario
    {
        [Key]
        
        public int Id { get; set; }
        
        //data anotations para validar dados antes de ir pro banco
        [Display(Name="Nome do Usuario")]
        [Required(ErrorMessage="Esse campo é Obrigatorio")]
        [MinLength(2, ErrorMessage="Você deve inserrir um nome com pelo menos 2 caracteres.")]
        [MaxLength(10, ErrorMessage="Você deve inserir um nome com menos de 10 caracteres.")]
        public string Nome { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z-'\s]{1,40}$", ErrorMessage="esse campo não permite caracteres especiais")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public Usuario()
        {
        }

        public Usuario(int Id, string Nome, string Login, string Senha, DateTime DataCadastro)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Login = Login;
            this.Senha = Senha;
            this.DataCadastro = DataCadastro;
        }
    }
}