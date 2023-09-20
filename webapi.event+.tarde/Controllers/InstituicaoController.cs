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
    public class InstituicaoController : ControllerBase
    {
        private IInstituicao _instituicaoRepository { get; set; }

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }
        /// <summary>
        /// Método para listar todas as instituições cadastradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                List<Instituicao> listaInstituicoes = _instituicaoRepository.ListarTodas();

                return StatusCode(200, listaInstituicoes);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para cadastrar uma instituição
        /// </summary>
        /// <param name="instituicao"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);
                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para deletar uma instituição
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                if (instituicaoBuscada != null)
                {
                    _instituicaoRepository.Deletar(id);
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
        /// Método para buscar uma instituição pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                if (instituicaoBuscada == null)
                {
                    return StatusCode(404);
                }
                else
                {
                    return StatusCode(200, instituicaoBuscada);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        /// <summary>
        /// Método para atualizar os dados de uma instituição
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instituicao"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Atualizar(Guid id, Instituicao instituicao)
        {
            try
            {
                Instituicao instituicaoBuscada = _instituicaoRepository.BuscarPorId(id);

                if (instituicaoBuscada != null)
                {
                    _instituicaoRepository.Atualizar(id, instituicao);
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
