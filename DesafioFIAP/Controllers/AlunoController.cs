using DesafioFIAP.Data;
using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace DesafioFIAP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : Controller
    {
        private readonly IAlunoService _alunoService;
        public AlunoController(AlunoService service)
        {
            _alunoService = service;
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
        /// Cadastra um novo aluno
        /// </summary>
        /// <param name="aluno">Objeto aluno</param>
        /// <returns>Aluno criado</returns>
        [Authorize]
        [HttpPost("Criar")]
        public IActionResult Criar([FromBody] CriarAlunoDTO aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _alunoService.CriarAluno(aluno);

                if (!result.Sucesso)
                    return BadRequest(result.Mensagem);
                else
                    return Ok(new
                    {
                        mensagem = "Aluno criado com sucesso."
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar aluno: {ex.Message}");
            }
        }

        /// <summary>
        /// Edita um aluno existente
        /// </summary>
        /// <param name="Id">Id do aluno</param>
        /// <param name="aluno">Objeto aluno</param>
        /// <returns>Aluno editado</returns>
        [Authorize]
        [HttpPut("Editar/{Id}")]
        public IActionResult Editar(int Id, [FromBody] EditarAlunoDTO aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _alunoService.EditarAluno(Id, aluno);

                if (!result.Sucesso)
                    return BadRequest(result.Mensagem);
                else
                    return Ok(new
                    {
                        mensagem = "Aluno editado com sucesso."
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao editar aluno: {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui um aluno existente
        /// </summary>
        /// <param name="Id">Id do aluno</param>
        /// <returns>Mensagem de excluído</returns>
        [Authorize]
        [HttpDelete("Excluir/{Id}")]
        public IActionResult Excluir(int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _alunoService.ExcluirAluno(Id);

                if (!result.Sucesso)
                    return BadRequest(result.Mensagem);
                else
                    return Ok(new
                    {
                        mensagem = "Aluno excluído com sucesso."
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir aluno: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista os alunos existentes
        /// </summary>
        /// <param name="numPag">Número da página</param>
        /// <param name="pagTam">Tamanho da página</param>
        /// <returns>Lista de alunos</returns>
        [Authorize]
        [HttpGet("Listar/{numPag}/{pagTam}")]
        public IActionResult Listar(int numPag, int pagTam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var alunos = _alunoService.ListarAlunos(numPag, pagTam);

                if (alunos.Dados.Count() == 0)
                    return NotFound("Nenhum aluno encontrado com o filtro fornecido.");

                return Ok(alunos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter lista de alunos: {ex.Message}");
            }
        }

        /// <summary>
        /// Lista os alunos existentes por pesquisa de nome
        /// </summary>
        /// <param name="Nome">Nome do aluno</param>
        /// <param name="numPag">Número da página</param>
        /// <param name="pagTam">Tamanho da página</param>
        /// <returns>Lista de alunos</returns>
        [Authorize]
        [HttpGet("Listar/{Nome}/{numPag}/{pagTam}")]
        public IActionResult ListarPorNome(string Nome, int numPag, int pagTam)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var alunos = _alunoService.ListarAlunosPorNome(Nome, numPag, pagTam);

                if (alunos.Dados.Count() == 0)
                    return NotFound("Nenhum aluno encontrado com o filtro fornecido.");

                if (!alunos.Sucesso)
                    return BadRequest(alunos.Mensagem);
                else
                    return Ok(alunos);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter lista de alunos: {ex.Message}");
            }
        }

    }
}
