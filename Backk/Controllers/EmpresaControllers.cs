using Microsoft.AspNetCore.Mvc;
using Backk.Models;
using Microsoft.EntityFrameworkCore;

namespace Backk.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly BdEmpresaContext _context;

    public EmpresaController(BdEmpresaContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmpresas()
    {
        return Ok(await _context.Empresas.ToListAsync());
    }
}
