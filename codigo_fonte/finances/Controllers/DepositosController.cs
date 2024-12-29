using AutoMapper;
using finances.Data;
using finances.Dtos.Deposito;
using finances.Models;
using Microsoft.AspNetCore.Mvc;

namespace finances.Controllers;

[ApiController]
[Route("[controller]")]
public class DepositosController : ControllerBase {

    private InstituicaoContext _context;
    private IMapper _mapper;

    public DepositosController(InstituicaoContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostDepositos(CreateDepositoDto depositosDto) {
        try {
            if(string.IsNullOrWhiteSpace(depositosDto.Descricao)) {
                return BadRequest("A descrição não pode estar vazia.");
            }

            if(ModelState.IsValid) {
                Deposito deposito = _mapper.Map<Deposito>(depositosDto);

                var instituicao = _context.Instituicoes.FirstOrDefault(i => i.Id == deposito.InstituicaoId);
                if(instituicao == null) {
                    return NotFound("Instituição não encontrada.");
                }

                instituicao.Receita += deposito.Valor;
                _context.Depositos.Add(deposito);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetDepositosPorId), new { id = deposito.Id }, deposito);
            }

            return BadRequest(ModelState);
        } catch(Exception ex) {
            Console.WriteLine($"Erro ao adicionar depósito: {ex.Message}");
            return StatusCode(500, "Ocorreu um erro ao processar sua solicitação. Tente novamente mais tarde.");
        }
    }

    [HttpGet("deposito/{id}")]
    public IActionResult GetDepositosPorId(int id) {
        var deposito = _context.Depositos.FirstOrDefault(f => f.Id == id);
        if(deposito == null) return NotFound();
        return Ok(deposito);
    }

    [HttpGet]
    public IEnumerable<ReadDepositoDto> GetAllDepositos() {
        var depositos = _context.Depositos.ToList();
        return _mapper.Map<List<ReadDepositoDto>>(depositos);
    }
}
