using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Repositories
{
    public interface IAlunoRepository
    {
        Task<IResponse<AlunoModel>> CriarAluno(AlunoModel aluno);
        Task<IResponse<AlunoModel>> EditarAluno(AlunoModel aluno);
        Task<IResponse<AlunoModel>> ExcluirAluno(AlunoModel aluno);
        IResponse<List<AlunoModel>> ListarAlunos(int numPag, int pagTam);
        IResponse<List<AlunoModel>> ListarAlunosPorNome(string Nome, int numPag, int pagTam);
    }
}
