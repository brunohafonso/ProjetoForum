using System;
using System.ComponentModel.DataAnnotations;

namespace projetoForum.Models
{
    public class Postagem
    {
        [Key]
        public int Id { get; set; }
        public int  IdTopico { get; set; }
        public int IdUsuario { get; set; }
        
        [Display(Name="descrição")]
        [Required(ErrorMessage="Esse campo é Obrigatorio")]
        [MinLength(5, ErrorMessage="Você deve inserrir um nome com pelo menos 5 caracteres.")]
        [MaxLength(150, ErrorMessage="Você deve inserir um nome com menos de 150 caracteres.")]
        public string Mensagem { get; set; }
        public DateTime DataPublicacao { get; set; }
        
        public Postagem()
        {
        }
        
        public Postagem(int Id, int IdTopico, int IdUsuario, string Mensagem, DateTime DataPublicacao)
        {
            this.Id = Id;
            this.IdTopico = IdTopico;
            this.IdUsuario = IdUsuario;
            this.Mensagem = Mensagem;
            this.DataPublicacao = DataPublicacao;
        }
    }
}