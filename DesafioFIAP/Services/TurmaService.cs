using DesafioFIAP.Data;
using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Repositories;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly AppDbContext _context;
        private readonly ITurmaRepository _repo;
        public TurmaService(ITurmaRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        public async Task<IResponse<TurmaModel>> CriarTurma(CriarTurmaDTO turma)
        {
            var novaTurma = new TurmaModel
            {
                Nome = turma.Nome,
                Descricao = turma.Descricao,
                DataInclusao = DateTime.Now,
                DataEdicao = null
            };

            return await _repo.CriarTurma(novaTurma);
        }
        public async Task<IResponse<TurmaModel>> EditarTurma(int Id, EditarTurmaDTO turmaEdicao)
        {
            var turma = _context.Turma.FindAsync(Id);

            var turmaObtida = turma.Result;

            if (turmaObtida == null)
                return Response<TurmaModel>.Falha("Turma não encontrada");

            turmaObtida.Nome = turmaEdicao.Nome;
            turmaObtida.Descricao = turmaEdicao.Descricao;
            turmaObtida.DataEdicao = DateTime.Now;

            return await _repo.EditarTurma(turmaObtida);
        }
        public async Task<IResponse<TurmaModel>> ExcluirTurma(int Id)
        {
            var turma = _context.Turma.FindAsync(Id);

            var turmaObtida = turma.Result;

            if (turmaObtida == null)
                return Response<TurmaModel>.Falha("Turma não encontrada");

            return await _repo.ExcluirTurma(turmaObtida);
        }
        public IResponse<List<TurmaQtdAlunosDTO>> ListarTurmas(int numPag, int pagTam)
        {
            return _repo.ListarTurmas(numPag, pagTam);
        }
        public IResponse<List<AlunosMatriculadosDTO>> ListarMatriculados(int Id, int numPag, int pagTam)
        {
            var matricula = _context.Matricula.FindAsync(Id);

            var matriculaObtida = matricula.Result;

            if (matriculaObtida == null)
                return Response<List<AlunosMatriculadosDTO>>.Falha("Matrícula não encontrada");

            return _repo.ListarMatriculados(Id, numPag, pagTam);
        }
    }
}
