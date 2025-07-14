using DesafioFIAP.Data;
using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Repositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly AppDbContext _context;

        public TurmaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IResponse<TurmaModel>> CriarTurma(TurmaModel turma)
        {
            try
            {
                _context.Turma.Add(turma);
                await _context.SaveChangesAsync();
                return Response<TurmaModel>.Ok(turma, "Turma cadastrada com sucesso.");
            }
            catch (Exception ex)
            {
                return Response<TurmaModel>.Falha("Erro ao cadastrar turma: " + ex.Message);
            }
        }

        public async Task<IResponse<TurmaModel>> EditarTurma(TurmaModel turma)
        {
            try
            {
                _context.Turma.Update(turma);
                await _context.SaveChangesAsync();
                return Response<TurmaModel>.Ok(turma, "Turma editada com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<TurmaModel>.Falha("Erro ao editar a turma: " + ex.Message);
            }
        }

        public async Task<IResponse<TurmaModel>> ExcluirTurma(TurmaModel turma)
        {
            try
            {
                _context.Turma.Remove(turma);
                await _context.SaveChangesAsync();
                return Response<TurmaModel>.Ok(turma, "Turma excluída com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<TurmaModel>.Falha("Erro ao excluir a turma: " + ex.Message);
            }

        }

        public IResponse<List<TurmaQtdAlunosDTO>> ListarTurmas(int numPag, int pagTam)
        {
            try
            {
                var turmas = (from turma in _context.Turma
                              join matricula in _context.Matricula
                                  on turma.Id equals matricula.TurmaId into grupoMatriculas
                              select new TurmaQtdAlunosDTO
                              {
                                  Id = turma.Id,
                                  Nome = turma.Nome,
                                  Descricao = turma.Descricao,
                                  DataInclusao = turma.DataInclusao,
                                  DataEdicao = turma.DataEdicao,
                                  QuantidadeAlunos = grupoMatriculas.Count()
                              }
                           ).OrderBy(a => a.Nome).Skip((numPag - 1) * pagTam).Take(pagTam).ToList();
                return Response<List<TurmaQtdAlunosDTO>>.Ok(turmas, "Listagem obtida com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<List<TurmaQtdAlunosDTO>>.Falha("Erro ao obter listagem: " + ex.Message);
            }

        }
        public IResponse<List<AlunosMatriculadosDTO>> ListarMatriculados(int Id, int numPag, int pagTam)
        {
            try
            {
                var matriculas = (from matricula in _context.Matricula
                                  join aluno in _context.Aluno on matricula.AlunoId equals aluno.Id
                                  join turma in _context.Turma on matricula.TurmaId equals turma.Id
                                  where turma.Id == Id
                                  select new AlunosMatriculadosDTO
                                  {
                                      AlunoId = aluno.Id,
                                      NomeAluno = aluno.Nome,
                                      Email = aluno.Email,
                                      Cpf = aluno.CPF,
                                      TurmaId = turma.Id,
                                      NomeTurma = turma.Nome,
                                      DescricaoTurma = turma.Descricao
                                  }).OrderBy(a => a.NomeTurma).Skip((numPag - 1) * pagTam).Take(pagTam).ToList();

                if (matriculas.Count > 0)
                    return Response<List<AlunosMatriculadosDTO>>.Ok(matriculas, "Listagem obtida com sucesso.");
                else
                    return Response<List<AlunosMatriculadosDTO>>.Falha("Não existem dados para a turma informada.");
            }
            catch (Exception ex)
            {
                return Response<List<AlunosMatriculadosDTO>>.Falha("Erro ao obter listagem: " + ex.Message);
            }

        }
    }
}
