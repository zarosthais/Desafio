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

        public async Task<IResponse<MatriculaModel>> CriarMatricula(MatriculaModel matricula)
        {
            try
            {
                _context.Matricula.Add(matricula);
                await _context.SaveChangesAsync();
                return Response<MatriculaModel>.Ok(matricula, "Matrícula efetuada com sucesso.");
            }
            catch (Exception ex)
            {
                return Response<MatriculaModel>.Falha("Erro ao cadastrar matrícula: " + ex.Message);
            }
        }


        public async Task<IResponse<MatriculaModel>> EditarMatricula(MatriculaModel matricula)
        {
            try
            {
                _context.Matricula.Update(matricula);
                await _context.SaveChangesAsync();
                return Response<MatriculaModel>.Ok(matricula, "Matricula editada com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<MatriculaModel>.Falha("Erro ao editar a matrícula: " + ex.Message);
            }
        }

        public async Task<IResponse<MatriculaModel>> ExcluirMatricula(MatriculaModel matricula)
        {
            try
            {
                _context.Matricula.Remove(matricula);
                await _context.SaveChangesAsync();
                return Response<MatriculaModel>.Ok(matricula, "Matricula excluída com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<MatriculaModel>.Falha("Erro ao excluir a matrícula: " + ex.Message);
            }

        }
    }
}