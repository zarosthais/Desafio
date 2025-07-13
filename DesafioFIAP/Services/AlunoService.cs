using DesafioFIAP.Data;
using DesafioFIAP.DTO;
using DesafioFIAP.Models;
using DesafioFIAP.Repositories;
using DesafioFIAP.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;

namespace DesafioFIAP.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly AppDbContext _context;
        private readonly IAlunoRepository _repo;
        public AlunoService(IAlunoRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }
        public IResponse<AlunoModel> CriarAluno(CriarAlunoDTO aluno)
        {
            bool cpfExiste = _context.Aluno.Any(a => a.CPF == aluno.CPF);
            if (cpfExiste)
                return Response<AlunoModel>.Falha("Já existe um aluno cadastrado com este CPF.");

            bool emailExiste = _context.Aluno.Any(a => a.Email == aluno.Email);
            if (emailExiste)
                return Response<AlunoModel>.Falha("Já existe um aluno cadastrado com este E-mail.");

            if (aluno.DataNascimento == default || aluno.DataNascimento < new DateTime(1900, 1, 1))
                return Response<AlunoModel>.Falha("Data de nascimento inválida.");

            string senhaHash = BCrypt.Net.BCrypt.HashPassword(aluno.Senha);

            var novoAluno = new AlunoModel
            {
                Nome = aluno.Nome,
                DataNascimento = aluno.DataNascimento,
                CPF = aluno.CPF,
                Email = aluno.Email,
                Senha = senhaHash,
                DataInclusao = DateTime.Now,
                DataEdicao = null
            };

            return _repo.CriarAluno(novoAluno);
        }

        public IResponse<AlunoModel> EditarAluno(int Id, EditarAlunoDTO alunoEdicao)
        {
            var aluno = _context.Aluno.FindAsync(Id);

            var alunoObtido = aluno.Result;

            if (alunoObtido == null)
                return Response<AlunoModel>.Falha("Aluno não encontrado");

            alunoObtido.Nome = alunoEdicao.Nome;
            alunoObtido.DataNascimento = alunoEdicao.DataNascimento;
            alunoObtido.DataEdicao = DateTime.Now;

            return _repo.EditarAluno(alunoObtido);
        }
        public IResponse<AlunoModel> ExcluirAluno(int Id)
        {
            var aluno = _context.Aluno.FindAsync(Id);

            var alunoObtido = aluno.Result;

            if (alunoObtido == null)
                return Response<AlunoModel>.Falha("Aluno não encontrado");

            return _repo.ExcluirAluno(alunoObtido);
        }
        public IResponse<List<AlunoModel>> ListarAlunos(int numPag, int pagTam)
        {
            return _repo.ListarAlunos(numPag, pagTam);
        }
        public IResponse<List<AlunoModel>> ListarAlunosPorNome(string Nome, int numPag, int pagTam)
        {
            return _repo.ListarAlunosPorNome(Nome, numPag, pagTam);
        }
    }
}
