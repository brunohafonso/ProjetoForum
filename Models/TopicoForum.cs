using System;

namespace projetoForum.Models
{
    public class TopicoForum
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public TopicoForum()
        {
        }
        public TopicoForum(int Id, string Titulo, string Descricao)
        {
            this.Id = Id;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.DataCadastro = DateTime.Now;
        }
    }
}