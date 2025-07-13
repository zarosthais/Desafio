using DesafioFIAP.Data;
using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;
using Microsoft.EntityFrameworkCore;

namespace DesafioFIAP.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly AppDbContext _context;

        public MatriculaRepository(AppDbContext context)
        {
            _context = context;
        }

        public IResponse<MatriculaModel> CriarMatricula(MatriculaModel matricula)
        {
            try
            {
                _context.Matricula.Add(matricula);
                _context.SaveChanges();
                return Response<MatriculaModel>.Ok(matricula, "Matrícula efetuada com sucesso.");
            }
            catch (Exception ex)
            {
                return Response<MatriculaModel>.Falha("Erro ao cadastrar matrícula: " + ex.Message);
            }
        }


        public IResponse<MatriculaModel> EditarMatricula(MatriculaModel matricula)
        {
            try
            {
                _context.Matricula.Update(matricula);
                _context.SaveChangesAsync();
                return Response<MatriculaModel>.Ok(matricula, "Matricula editada com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<MatriculaModel>.Falha("Erro ao editar a matrícula: " + ex.Message);
            }
        }

        public IResponse<MatriculaModel> ExcluirMatricula(MatriculaModel matricula)
        {
            try
            {
                _context.Matricula.Remove(matricula);
                _context.SaveChangesAsync();
                return Response<MatriculaModel>.Ok(matricula, "Matricula excluída com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<MatriculaModel>.Falha("Erro ao excluir a matrícula: " + ex.Message);
            }

        }
    }
}