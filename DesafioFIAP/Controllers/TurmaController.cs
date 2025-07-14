using DesafioFIAP.DTO;
using DesafioFIAP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioFIAP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmaController : Controller
    {
        private readonly ITurmaService _turmaService;
        public TurmaController(TurmaService service)
        {
            _turmaService = service;
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
        /// Cadastra uma nova turma
        /// </summary>
        /// <param name="turma">Objeto turma</param>
        /// <returns>Turma criado</returns>
        [Authorize]
        [HttpPost("Criar")]
        public async Task<IActionResult> Criar([FromBody] CriarTurmaDTO turma)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _turmaService.CriarTurma(turma);

                return Ok(new
                {
                    mensagem = "Turma criada com sucesso."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar turma: {ex.Message}");
            }
        }
        /// <summary>
        /// Edita uma turma existente
        /// </summary>
        /// <param name="Id">Id da turma</param>
        /// <param name="turma">Objeto turma</param>
        /// <returns>Turma editada</returns>
        [Authorize]
        [HttpPut("Editar/{Id}")]
        public async Task<IActionResult> Editar(int Id, [FromBody] EditarTurmaDTO turma)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _turmaService.EditarTurma(Id, turma);

                if (!result.Sucesso)
                    return BadRequest(result.Mensagem);
                else
                    return Ok(new
                    {
                        mensagem = "Turma editada com sucesso."
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao editar turma: {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui uma turma existente
        /// </summary>
        /// <param name="Id">Id da turma</param>
        /// <returns>Mensagem de excluído</returns>
        [Authorize]
        [HttpDelete("Excluir/{Id}")]
        public async Task<IActionResult> Excluir(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _turmaService.ExcluirTurma(Id);

                if (!result.Sucesso)
                    return BadRequest(result.Mensagem);
                else
                    return Ok(new
                    {
                        mensagem = "Turma excluída com sucesso."
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir turma: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista as turmas existentes
        /// </summary>
        /// <param name="numPag">Número da página</param>
        /// <param name="pagTam">Tamanho da página</param>
        /// <returns>Lista de turmas</returns>
        [Authorize]
        [HttpGet("Listar/{numPag}/{pagTam}")]
        public IActionResult Listar(int numPag, int pagTam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var turmas = _turmaService.ListarTurmas(numPag, pagTam);

                if (turmas.Dados.Count() == 0)
                    return NotFound("Nenhuma turma encontrada com o filtro fornecido.");

                return Ok(turmas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter lista de turmas: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista de alunos matriculados em uma turma
        /// </summary>
        /// <param name="Id">Id da turma</param>
        /// <param name="numPag">Número da página</param>
        /// <param name="pagTam">Tamanho da página</param>
        /// <returns>Lista de matrículas</returns>
        [Authorize]
        [HttpGet("Matriculados/{Id}/{numPag}/{pagTam}")]
        public IActionResult Matriculados(int Id, int numPag, int pagTam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var matricula = _turmaService.ListarMatriculados(Id, numPag, pagTam);

                if (matricula.Dados.Count() == 0)
                    return NotFound("Nenhuma turma encontrada com o filtro fornecido.");

                if (!matricula.Sucesso)
                    return BadRequest(matricula.Mensagem);
                else
                    return Ok(matricula);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter lista: {ex.Message}");
            }
        }
    }
}
