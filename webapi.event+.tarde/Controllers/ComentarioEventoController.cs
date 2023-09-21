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
    public class ComentarioEventoController : ControllerBase
    {
        private IComentarioEvento _comentarioEventoRepository { get; set; }
        public ComentarioEventoController()
        {
            _comentarioEventoRepository = new ComentarioEventoRepository();
        }
        /// <summary>
        /// Método para adicionar um comentário sobre um evento
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(ComentarioEvento c)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(c);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para deletar um comentário de um evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                ComentarioEvento comentarioBuscado = _comentarioEventoRepository.BuscarPorId(id);

                if (comentarioBuscado != null)
                {
                    _comentarioEventoRepository.Deletar(id);
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
        /// <summary>
        /// Método para buscar um comentário pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                ComentarioEvento comentarioBuscado = _comentarioEventoRepository.BuscarPorId(id);
                return StatusCode(200, comentarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
        /// <summary>
        /// Método para listar todos os comentários de todos os eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult ListarTodos()
        {
            try
            {
                return StatusCode(200, _comentarioEventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
