using System;

namespace projetoForum.Models
{
    public class Postagem
    {
        public int Id { get; set; }
        public int  IdTopico { get; set; }
        public int IdUsuario { get; set; }
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