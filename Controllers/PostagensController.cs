using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using projetoForum.DAO;
using projetoForum.Models;

namespace ProjetoForum.Controllers {

    public class PostagensController {

        DAOPostagem dao = new DAOPostagem ();
        [Route ("API/[Controller]")]

        [HttpGet]
        [Route ("API/listarPostagens")]
        public IEnumerable<Postagem> Listar () {
            return dao.Listar ();
        }

        [HttpPost]
        [Route ("API/cadastrarPostagem")]
        public bool Cadastrar ([FromBody] Postagem post) {
            return dao.Cadastrar (post);
        }

        [HttpPut]
        [Route ("API/AtualizarPostagem")]
        public bool Editar ([FromBody] Postagem post) {
            return dao.Editar (post);
        }

        [HttpDelete ("{Id}")]
        [Route ("API/deletarPostagem/{Id}")]
        public bool Deletar (int Id) {
            return dao.Deletar (Id);
        }
    }
}