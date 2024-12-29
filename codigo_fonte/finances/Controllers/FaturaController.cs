using AutoMapper;
using finances.Data;
using finances.Dtos.FaturaCredito;
using finances.Models;
using Microsoft.AspNetCore.Mvc;

namespace finances.Controllers;

[ApiController]
[Route("[controller]")]
public class FaturaController : ControllerBase {

    private InstituicaoContext _context;
    private IMapper _mapper;

    public FaturaController(InstituicaoContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostFatura(CreateFaturaDto faturaDto) {
        if (string.IsNullOrWhiteSpace(faturaDto.Descricao)) {
            return BadRequest("A descrição não pode estar vazia.");
        }

        if (ModelState.IsValid) {
            FaturaCredito fatura = _mapper.Map<FaturaCredito>(faturaDto);
            _context.FaturasCredito.Add(fatura);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFaturaPorId), new { id = fatura.Id }, fatura);
        }
        return BadRequest(ModelState);
    }

    [HttpGet("fatura/{id}")]
    public IActionResult GetFaturaPorId(int id) {
        var fatura = _context.FaturasCredito.FirstOrDefault(f => f.Id == id);
        if (fatura == null) return NotFound();
        return Ok(fatura);
    }

    [HttpGet]
    public IEnumerable<ReadFaturaDto> GetAllFaturas() {
        var faturas = _context.FaturasCredito.ToList();
        return _mapper.Map<List<ReadFaturaDto>>(faturas);
    }
}
