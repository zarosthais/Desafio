using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Repositories
{
    public interface IMatriculaRepository
    {
        IResponse<MatriculaModel> CriarMatricula(MatriculaModel turma);
        IResponse<MatriculaModel> EditarMatricula(MatriculaModel turma);
        IResponse<MatriculaModel> ExcluirMatricula(MatriculaModel turma); 
    }
}
