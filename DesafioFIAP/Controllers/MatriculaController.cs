using DesafioFIAP.DTO;
using DesafioFIAP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFIAP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : Controller
    {
        private readonly IMatriculaService _matriculaService;
        public MatriculaController(MatriculaService service)
        {
            _matriculaService = service;
        }
        /// <summary>
        /// Retorna se o usuário está autenticado para acessar o endpoint
        /// </summary>
        /// <returns>Autenticação</returns>
        [Authorize]
        [HttpGet("Autorizado")]
        public IActionResult Get()
        {
            return Ok("Você está autenticado e pode acessar esse endpoint protegido!");
        }

        /// <summary>
        /// Cria uma nova matrícula
        /// </summary>
        /// <param name="matricula">Objeto matricula</param>
        /// <returns>Matrícula criada</returns>
        [Authorize]
        [HttpPost("Criar")]
        public IActionResult Criar([FromBody] CriarMatriculaDTO matricula)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _matriculaService.CriarMatricula(matricula);

                if (!result.Sucesso)
                    return BadRequest(result.Mensagem);
                else
                    return Ok(new
                    {
                        mensagem = "Matrícula criada com sucesso."
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar matrícula: {ex.Message}");
            }
        }
        /// <summary>
        /// Edita uma matricula existente
        /// </summary>
        /// <param name="Id">Id da matricula</param>
        /// <param name="matricula">Objeto matricula</param>
        /// <returns>Matricula editada</returns>
        [Authorize]
        [HttpPut("Editar/{Id}")]
        public IActionResult Editar(int Id, [FromBody] EditarMatriculaDTO matricula)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _matriculaService.EditarMatricula(Id, matricula);

                if (!result.Sucesso)
                    return BadRequest(result.Mensagem);
                else
                    return Ok(new
                    {
                        mensagem = "Matrícula editada com sucesso."
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao editar matrícula: {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui uma matricula existente
        /// </summary>
        /// <param name="Id">Id da matricula</param>
        /// <returns>Mensagem de excluído</returns>
        [Authorize]
        [HttpDelete("Excluir/{Id}")]
        public IActionResult Excluir(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _matriculaService.ExcluirMatricula(Id);

                if (!result.Sucesso)
                    return BadRequest(result.Mensagem);
                else
                    return Ok(new
                    {
                        mensagem = "Matrícula excluída com sucesso."
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir matrícula: {ex.Message}");
            }
        }
    }
}
