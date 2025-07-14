using DesafioFIAP.Data;
using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Responses;
using Microsoft.EntityFrameworkCore;

namespace DesafioFIAP.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IResponse<AlunoModel>> CriarAluno(AlunoModel aluno)
        {
            try
            {
                _context.Aluno.Add(aluno);
                await _context.SaveChangesAsync();
                return Response<AlunoModel>.Ok(aluno, "Aluno cadastrado com sucesso.");
            }
            catch (Exception ex)
            {
                return Response<AlunoModel>.Falha("Erro ao cadastrar aluno: " + ex.Message);
            }
        }

        public async Task<IResponse<AlunoModel>> EditarAluno(AlunoModel aluno)
        {
            try
            {
                _context.Aluno.Update(aluno); 
                await _context.SaveChangesAsync();
                return Response<AlunoModel>.Ok(aluno, "Aluno editado com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<AlunoModel>.Falha("Erro ao editar o aluno: " + ex.Message);
            }
        }

        public async Task<IResponse<AlunoModel>> ExcluirAluno(AlunoModel aluno)
        {
            try
            {
                _context.Aluno.Remove(aluno);
                await _context.SaveChangesAsync();
                return Response<AlunoModel>.Ok(aluno, "Aluno excluído com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<AlunoModel>.Falha("Erro ao excluir o aluno: " + ex.Message);
            }

        }

        public IResponse<List<AlunoModel>> ListarAlunos(int numPag, int pagTam)
        {
            try
            {      
                var alunos = _context.Aluno.OrderBy(a => a.Nome).Skip((numPag - 1) * pagTam).Take(pagTam).ToList();
                return Response<List<AlunoModel>>.Ok(alunos, "Listagem obtida com sucesso.");

            }
            catch (Exception ex)
            {
                return Response<List<AlunoModel>>.Falha("Erro ao obter listagem: " + ex.Message);
            }

        }
         
        public IResponse<List<AlunoModel>> ListarAlunosPorNome(string Nome, int numPag, int pagTam)
        {
            try
            {
                var alunos = _context.Aluno.Where(n => n.Nome.ToLower().Contains(Nome)).OrderBy(a => a.Nome).Skip((numPag - 1) * pagTam).Take(pagTam).ToList();
                return Response<List<AlunoModel>>.Ok(alunos, "Listagem obtida com sucessos.");

            }
            catch (Exception ex)
            {
                return Response<List<AlunoModel>>.Falha("Erro ao obter listagem: " + ex.Message);
            }

        }

    }
}
