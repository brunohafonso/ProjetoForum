using System;
using System.ComponentModel.DataAnnotations;

namespace projetoForum.Models
{
    public class TopicoForum
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Titulo da categoria")]
        [Required(ErrorMessage="Esse campo é Obrigatorio")]
        [MinLength(3, ErrorMessage="Você deve inserrir um nome com pelo menos 3 caracteres.")]
        [MaxLength(20, ErrorMessage="Você deve inserir um nome com menos de 20 caracteres.")]
        public string Titulo { get; set; }

        [Display(Name="descrição")]
        [Required(ErrorMessage="Esse campo é Obrigatorio")]
        [MinLength(10, ErrorMessage="Você deve inserrir um nome com pelo menos 10 caracteres.")]
        [MaxLength(25, ErrorMessage="Você deve inserir um nome com menos de 25 caracteres.")]
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public TopicoForum()
        {
        }
        public TopicoForum(int Id, string Titulo, string Descricao, DateTime DataCadastro)
        {
            this.Id = Id;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.DataCadastro = DataCadastro;
        }
    }
}