using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Repositories
{
    public interface IMatriculaRepository
    {
        Task<IResponse<MatriculaModel>> CriarMatricula(MatriculaModel turma);
        Task<IResponse<MatriculaModel>> EditarMatricula(MatriculaModel turma);
        Task<IResponse<MatriculaModel>> ExcluirMatricula(MatriculaModel turma);
    }
}
