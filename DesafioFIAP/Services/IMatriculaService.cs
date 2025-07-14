using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Services
{
    public interface IMatriculaService
    {
        Task<IResponse<MatriculaModel>> CriarMatricula(CriarMatriculaDTO matricula);
        Task<IResponse<MatriculaModel>> EditarMatricula(int Id, EditarMatriculaDTO matriculaEdicao);
        Task<IResponse<MatriculaModel>> ExcluirMatricula(int Id);
    }
}
