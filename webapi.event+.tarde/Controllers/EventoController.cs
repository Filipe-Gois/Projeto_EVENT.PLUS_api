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
    public class EventoController : ControllerBase
    {
        private IEvento _eventoRepository { get; set; }
        public EventoController()
        {
            _eventoRepository = new EventoRepository();
        }
        /// <summary>
        /// Método para listar todos os eventos cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult ListarEventos()
        {
            try
            {
                return StatusCode(200, _eventoRepository.ListarEventos());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para cadastrar um evento
        /// </summary>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para buscar um evento pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                if (eventoBuscado != null)
                {
                    return StatusCode(200, eventoBuscado);
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
        /// Método para deletar um evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                if (eventoBuscado != null)
                {
                    _eventoRepository.Deletar(id);
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
        /// Método para atualizar os dados dde um evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Atualizar(Guid id, Evento evento)
        {
            try
            {
                Evento eventoBuscado = _eventoRepository.BuscarPorId(id);

                if (eventoBuscado != null)
                {
                    _eventoRepository.Atualizar(id, evento);
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
