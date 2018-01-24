using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using projetoForum.DAO;
using projetoForum.Models;

namespace projetoForum.Controllers
{

    public class UsuariosController : Controller
    {

        DAOUsuario dao = new DAOUsuario();
        [Route("API/[Controller]")]

        [HttpGet]
        //[Route("API/listarUsuarios")]
        public IEnumerable<Usuario> Listar()
        {
            return dao.ListarUsuarios();
        }

        [HttpGet("{Id}")]
        [Route("API/[Controller]/{Id}")]
        public IActionResult Listar(int Id)
        {
            //criando resultado em json buscando Id
            var rs = new JsonResult(dao.ListarUsuarios().Where(c => c.Id == Id).FirstOrDefault());
            //verificando se o valor do json é vazio
            if (rs.Value == null)
            {
                //definindo resultado para o formato de json
                rs.ContentType = "aplication/json";
                //definindo statusCode
                rs.StatusCode = 204;
                //definindo valor do json de retorno
                rs.Value = $"Não há resultados para a busca por esse usuario: {Id}";
            }
            else
            {
                rs.StatusCode = 200;
            }

            return Json(rs);
        }

        [HttpPost]
        [Route("API/cadastrarUsuario")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            JsonResult rs = null;
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                rs = new JsonResult(dao.Cadastrar(usuario));
                rs.ContentType = "application/json";
                if (!Convert.ToBoolean(rs.Value))
                {
                    rs.StatusCode = 404;
                    rs.Value = "Ocorreu um erro.";
                }
                else
                {
                    rs.StatusCode = 200;
                }
            }
            catch (SystemException ex)
            {
                rs = new JsonResult("");
                rs.StatusCode = 204;
                rs.Value = ex.Message;
            }

            return Json(rs);
        }

        [HttpPut]
        [Route("API/atualizarUsuario")]
        public bool Atualizar([FromBody] Usuario usuario)
        {
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