using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Repositories
{
    public interface IAlunoRepository
    {
        IResponse<AlunoModel> CriarAluno(AlunoModel aluno);
        IResponse<AlunoModel> EditarAluno(AlunoModel aluno);
        IResponse<AlunoModel> ExcluirAluno(AlunoModel aluno);
        IResponse<List<AlunoModel>> ListarAlunos(int numPag, int pagTam);
        IResponse<List<AlunoModel>> ListarAlunosPorNome(string Nome, int numPag, int pagTam);
    }
}
