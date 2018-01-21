using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using projetoForum.DAO;
using projetoForum.Models;

namespace projetoForum.Controllers {

    public class TopicosForumController : Controller {

        DAOTopicoForum dao = new DAOTopicoForum ();
        [Route ("API/[Controller]")]

        [HttpGet]
        [Route("API/listarTopicos")]
        public IEnumerable<TopicoForum> Listar () {
            return dao.Listar ();
        }

        [HttpPost]
        [Route("API/cadastrarTopico")]
        public bool Cadastrar ([FromBody] TopicoForum topico) {
            return dao.Cadastrar (topico);
        }

        [HttpPut]
        [Route("API/editarTopico")]
        public bool Editar ([FromBody] TopicoForum topico) {
            return dao.Editar (topico);
        }

        [HttpDelete("{Id}")]
        [Route("API/deletarTopico/{Id}")]
        public bool Deletar (int Id) {
            return dao.Deletar (Id);
        }
    }
}