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
    [Authorize(Roles = "Administrador")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }
        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Método para cadastrar um tipo de usuário
        /// </summary>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
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
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioBuscado == null)
                {
                    return StatusCode(404, "Tipo de usuário não encontrado");
                }

                else
                {
                    return StatusCode(200, tipoUsuarioBuscado);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para deletar um tipo de usuário
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioBuscado != null)
                {
                    _tipoUsuarioRepository.Deletar(id);
                    return StatusCode(200);
                }
                else
                {
                    return StatusCode(404, "Tipo de usuário não encontrado!");
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para listar todos os tipos de usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                List<TipoUsuario> listaTiposDeUsuarios = _tipoUsuarioRepository.Listar();
                return StatusCode(200, listaTiposDeUsuarios);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para atualizar o nome do tipo de um usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tpu"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Atualizar(Guid id, TipoUsuario tpu)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);

                if (tipoUsuarioBuscado != null)
                {
                    _tipoUsuarioRepository.Atualizar(id, tpu);

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
