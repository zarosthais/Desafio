using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;

namespace DesafioFIAP.Services
{
    public interface IMatriculaService
    {
        IResponse<MatriculaModel> CriarMatricula(CriarMatriculaDTO matricula);
        IResponse<MatriculaModel> EditarMatricula(int Id, EditarMatriculaDTO matriculaEdicao);
        IResponse<MatriculaModel> ExcluirMatricula(int Id);
    }
}
