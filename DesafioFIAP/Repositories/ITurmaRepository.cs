using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Repositories
{
    public interface ITurmaRepository
    {
        IResponse<TurmaModel> CriarTurma(TurmaModel turma);
        IResponse<TurmaModel> EditarTurma(TurmaModel turma);
        IResponse<TurmaModel> ExcluirTurma(TurmaModel turma);
        IResponse<List<TurmaQtdAlunosDTO>> ListarTurmas(int numPag, int pagTam);
        IResponse<List<AlunosMatriculadosDTO>> ListarMatriculados(int Id, int numPag, int pagTam);
    }
}
