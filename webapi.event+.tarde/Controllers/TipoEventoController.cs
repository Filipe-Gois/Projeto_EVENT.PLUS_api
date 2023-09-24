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
    public class TipoEventoController : ControllerBase
    {
        private ITipoEvento _tipoEventoRepository { get; set; }
        public TipoEventoController()
        {
            _tipoEventoRepository = new TipoEventoRepository();
        }
        /// <summary>
        /// Método para atualizar os dados do tipo d eum evento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "Administrador")]
        public IActionResult Atualizar(Guid id, TipoEvento tp)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

                if (tipoEventoBuscado != null)
                {
                    _tipoEventoRepository.Atualizar(id, tp);

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
        /// Método para listar todos os tipos de evento
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return StatusCode(200, _tipoEventoRepository.ListarTipos());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para buscar um tipo de evento através de seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

                if (tipoEventoBuscado != null)
                {
                    return StatusCode(200, tipoEventoBuscado);
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
        /// Método para cadastrar um tipo de evento
        /// </summary>
        /// <param name="tp"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(TipoEvento tp)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(tp);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para deletar um tipo de evento
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);

                if (tipoEventoBuscado != null)
                {
                    _tipoEventoRepository.Deletar(id);
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
