using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Método para cadastrar um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para buscar um usuário através de seu email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        [HttpGet("{email}")]
        public IActionResult BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(email, senha);

                if (usuarioBuscado == null)
                {
                    return StatusCode(404, "Usuário não encontrado");
                }
                return StatusCode(200, usuarioBuscado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para buscar um usuário pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    return StatusCode(200, usuarioBuscado);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Método para listar todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return StatusCode(200, _usuarioRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para atualizar os dados de um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Atualizar(Guid id, Usuario usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    _usuarioRepository.Atualizar(id, usuario);

                    return StatusCode(201);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                {
                    _usuarioRepository.Deletar(id);
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(404);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
