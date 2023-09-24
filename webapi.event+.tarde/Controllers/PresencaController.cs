using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaController : ControllerBase
    {
        private IPresencaEvento _presencaEvntoRepository { get; set; }
        public PresencaController()
        {
            _presencaEvntoRepository = new PresencaEventoRepository();
        }
        /// <summary>
        /// Método para inscrever um usuário em um evento
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Inscrever(PresencaEvento p)
        {
            try
            {
                _presencaEvntoRepository.Inscrever(p);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para excluir a presença do usuário de um determinado evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                PresencaEvento presencaBuscada = _presencaEvntoRepository.BuscarPorId(id);

                if (presencaBuscada != null)
                {
                    _presencaEvntoRepository.Deletar(id);
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
        /// Método para listar os eventos na qual um usuário participará
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Comum")]
        public IActionResult ListarMinhas(Guid id)
        {
            try
            {
                return StatusCode(200, _presencaEvntoRepository.ListarMinhas(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para listar todos os usuários cadastrar em cada evento
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Listar()
        {
            try
            {
                return StatusCode(200, _presencaEvntoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para alterar os dados de uma presença de evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="presenca"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Atualizar(Guid id, PresencaEvento presenca)
        {
            try
            {
                PresencaEvento presencaBuscada = _presencaEvntoRepository.BuscarPorId(id);

                if (presencaBuscada != null)
                {
                    _presencaEvntoRepository.Atualizar(id, presenca);
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
