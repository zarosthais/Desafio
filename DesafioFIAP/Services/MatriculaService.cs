using DesafioFIAP.Data;
using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Repositories;
using DesafioFIAP.Responses;
using Microsoft.EntityFrameworkCore;

namespace DesafioFIAP.Services
{
    public class MatriculaService : IMatriculaService
    {
        private readonly AppDbContext _context;
        private readonly IMatriculaRepository _repo;
        public MatriculaService(IMatriculaRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        public async Task<IResponse<MatriculaModel>> CriarMatricula(CriarMatriculaDTO matricula)
        {
            var aluno = _context.Aluno.FindAsync(matricula.AlunoId);

            var alunoObtido = aluno.Result;

            if (alunoObtido == null)
                return Response<MatriculaModel>.Falha("Aluno não encontrado");

            var turma = _context.Turma.FindAsync(matricula.TurmaId);

            var turmaObtida = turma.Result;

            if (turmaObtida == null)
                return Response<MatriculaModel>.Falha("Turma não encontrada");

            bool jaMatriculado = _context.Matricula.Any(m => m.AlunoId == matricula.AlunoId && m.TurmaId == matricula.TurmaId);

            if (jaMatriculado)
                return Response<MatriculaModel>.Falha("Esse aluno já está matriculado nesta turma.");

            var novaMatricula = new MatriculaModel
            {
                TurmaId = matricula.TurmaId,
                AlunoId = matricula.AlunoId,
                DataInclusao = DateTime.Now,
            };

            return await _repo.CriarMatricula(novaMatricula);
        }

        public async Task<IResponse<MatriculaModel>> EditarMatricula(int Id, EditarMatriculaDTO matriculaEdicao)
        {
            var matricula = _context.Matricula.FindAsync(Id);

            var matriculaObtida = matricula.Result;

            if (matriculaObtida == null)
                return Response<MatriculaModel>.Falha("Matrícula não encontrada");

            matriculaObtida.TurmaId = matriculaEdicao.TurmaId;
            matriculaObtida.DataEdicao = DateTime.Now;

            return await _repo.EditarMatricula(matriculaObtida);
        }
        public async Task<IResponse<MatriculaModel>> ExcluirMatricula(int Id)
        {
            var matricula = _context.Matricula.FindAsync(Id);

            var matriculaObtida = matricula.Result;

            if (matriculaObtida == null)
                return Response<MatriculaModel>.Falha("Matrícula não encontrada");

            return await _repo.ExcluirMatricula(matriculaObtida);
        }

    }
}
