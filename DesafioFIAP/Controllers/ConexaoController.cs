using DesafioFIAP.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ConexaoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ConexaoController(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Teste de conexão com o banco
    /// </summary>
    /// <returns>Conexão ok</returns>
    [HttpGet("teste")]
    public async Task<IActionResult> TesteConexao()
    {
        return Ok("Conectado com sucesso!");
    }
}
