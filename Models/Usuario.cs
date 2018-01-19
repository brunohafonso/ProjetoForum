using System;

namespace projetoForum.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
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