using AutoMapper;
using finances.Data;
using finances.Dtos.Debito;
using finances.Models;
using Microsoft.AspNetCore.Mvc;

namespace finances.Controllers;

[ApiController]
[Route("[controller]")]
public class DebitoController : ControllerBase {

    private InstituicaoContext _context;
    private IMapper _mapper;

    public DebitoController(InstituicaoContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostDebito(CreateDebitoDto debitoDto) {
        try {
            if(string.IsNullOrWhiteSpace(debitoDto.Descricao)) {
                return BadRequest("A descrição não pode estar vazia.");
            }

            if(ModelState.IsValid) {
                Debito debito = _mapper.Map<Debito>(debitoDto);

                var instituicao = _context.Instituicoes.FirstOrDefault(i => i.Id == debito.InstituicaoId);
                if(instituicao == null) {
                    return NotFound("Instituição não encontrada.");
                }

                instituicao.Receita -= debito.Valor;
                _context.Debitos.Add(debito);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetDebitoPorId), new { id = debito.Id }, debito);
            }

            return BadRequest(ModelState);
        } catch(Exception ex) {
            Console.WriteLine($"Erro ao adicionar depósito: {ex.Message}");
            return StatusCode(500, "Ocorreu um erro ao processar sua solicitação. Tente novamente mais tarde.");
        }
    }

    [HttpGet("debito/{id}")]
    public IActionResult GetDebitoPorId(int id) {
        var debito = _context.Debitos.FirstOrDefault(f => f.Id == id);
        if(debito == null) return NotFound();
        return Ok(debito);
    }

    [HttpGet]
    public IEnumerable<ReadDebitoDto> GetAllDebitos() {
        var debitos = _context.Debitos.ToList();
        return _mapper.Map<List<ReadDebitoDto>>(debitos);
    }
}
