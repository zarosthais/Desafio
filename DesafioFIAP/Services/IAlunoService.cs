using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Services
{
    public interface IAlunoService
    {
        IResponse<AlunoModel> CriarAluno(CriarAlunoDTO aluno);
        IResponse<AlunoModel> EditarAluno(int Id, EditarAlunoDTO alunoEdicao);
        IResponse<AlunoModel> ExcluirAluno(int Id);
        IResponse<List<AlunoModel>> ListarAlunos(int numPag, int pagTam);
        IResponse<List<AlunoModel>> ListarAlunosPorNome(string Nome, int numPag, int pagTam);
    }
}
