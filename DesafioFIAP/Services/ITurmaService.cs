using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Services
{
    public interface ITurmaService
    {
        Task<IResponse<TurmaModel>> CriarTurma(CriarTurmaDTO turma);
        Task<IResponse<TurmaModel>> EditarTurma(int Id, EditarTurmaDTO turmaEdicao);
        Task<IResponse<TurmaModel>> ExcluirTurma(int Id);
        IResponse<List<TurmaQtdAlunosDTO>> ListarTurmas(int numPag, int pagTam);
        IResponse<List<AlunosMatriculadosDTO>> ListarMatriculados(int Id, int numPag, int pagTam);
    }
}
