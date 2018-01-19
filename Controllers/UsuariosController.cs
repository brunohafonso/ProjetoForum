using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using projetoForum.DAO;
using projetoForum.Models;

namespace projetoForum.Controllers
{
    public class UsuariosController : Controller
    {
        DAOUsuario dao = new DAOUsuario();

        [HttpGet]
        [Route("API/listarUsuarios")]
        public IEnumerable<Usuario> Listar()
        {
            return dao.ListarUsuarios();
        }

        [HttpPost]
        [Route("API/cadastrarUsuario")]
        public bool Cadastrar([FromBody] Usuario usuario)
        {
            return dao.Cadastrar(usuario);
        }

        [HttpPut]
        [Route("API/atualizarUsuario")]
        public bool Atualizar([FromBody] Usuario usuario) {
            return dao.Editar(usuario);
        }

        [HttpDelete("{Id}")]
        [Route("API/deletarUsuario/{Id}")]
        public bool Deletar(int Id)
        {
            return dao.Deletar(Id);
        }
    }
}