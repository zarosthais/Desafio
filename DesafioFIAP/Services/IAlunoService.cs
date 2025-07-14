using Azure;
using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Services
{
    public interface IAlunoService
    {
        Task<IResponse<AlunoModel>> CriarAluno(CriarAlunoDTO aluno);
        Task<IResponse<AlunoModel>> EditarAluno(int Id, EditarAlunoDTO alunoEdicao);
        Task<IResponse<AlunoModel>> ExcluirAluno(int Id);
        IResponse<List<AlunoModel>> ListarAlunos(int numPag, int pagTam);
        IResponse<List<AlunoModel>> ListarAlunosPorNome(string Nome, int numPag, int pagTam);
    }
}
