using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Repositories
{
    public interface ITurmaRepository
    {
        Task<IResponse<TurmaModel>> CriarTurma(TurmaModel turma);
        Task<IResponse<TurmaModel>> EditarTurma(TurmaModel turma);
        Task<IResponse<TurmaModel>> ExcluirTurma(TurmaModel turma);
        IResponse<List<TurmaQtdAlunosDTO>> ListarTurmas(int numPag, int pagTam);
        IResponse<List<AlunosMatriculadosDTO>> ListarMatriculados(int Id, int numPag, int pagTam);
    }
}
