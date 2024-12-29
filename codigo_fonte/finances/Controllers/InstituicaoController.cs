using AutoMapper;
using finances.Data;
using finances.Dtos.Instituicao;
using finances.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace finances.Controllers;

[ApiController]
[Route("[controller]")]
public class InstituicaoController : ControllerBase {

    private InstituicaoContext _context;
    private IMapper _mapper;

    public InstituicaoController(InstituicaoContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostInstituicao([FromBody] CreateInstituicaoDto formInstituicaoDto) {
        if (string.IsNullOrWhiteSpace(formInstituicaoDto.Nome)) {
            return BadRequest("O nome da instituição não pode estar vazio.");
        }

        //verifica se já existe uma instituição com o mesmo nome
        bool nomeExistente = _context.Instituicoes.Any(i => i.Nome == formInstituicaoDto.Nome);
        if (nomeExistente) {
            return BadRequest("Já existe uma instituição com esse nome.");
        }

        if (ModelState.IsValid) {
            Instituicao formInstituicao = _mapper.Map<Instituicao>(formInstituicaoDto);
            _context.Instituicoes.Add(formInstituicao);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetInstituicaoPorId), new { id = formInstituicao.Id }, formInstituicao);
        }

        return BadRequest(ModelState);
    }

    [HttpPut("{id}/receita")]
    public IActionResult PutReceitaInstituicao(int id, [FromBody] UpdateSaldoDto saldoDto) {
        if (saldoDto == null || saldoDto.Receita <= 0) {
            return BadRequest("A receita deve ser um valor válido maior que zero.");
        }

        var instituicao = _context.Instituicoes.FirstOrDefault(i => i.Id == id);
        if (instituicao == null) {
            return NotFound("Instituição não encontrada.");
        }

        instituicao.Receita += saldoDto.Receita;
        _context.SaveChanges();

        return NoContent(); //retorna um status 204
    }

    [HttpPut("{id}/debito")]
    public IActionResult PutDebitoInstituicao(int id, [FromBody] UpdateSaldoDto saldoDto) {
        if (saldoDto == null || saldoDto.Receita <= 0) {
            return BadRequest("O débito deve ser um valor válido maior que zero.");
        }

        var instituicao = _context.Instituicoes.FirstOrDefault(i => i.Id == id);
        if (instituicao == null) {
            return NotFound("Instituição não encontrada.");
        }

        instituicao.Receita -= saldoDto.Receita;
        _context.SaveChanges();

        return NoContent(); //retorna um status 204
    }

    [HttpPut("{id}/despesa")]
    public IActionResult PutDespesaInstituicao(int id, [FromBody] UpdateCreditoDto despesaDto) {
        if (despesaDto == null || despesaDto.Despesa <= 0) {
            return BadRequest("O crédito deve ser um valor válido maior que zero.");
        }

        var instituicao = _context.Instituicoes.FirstOrDefault(i => i.Id == id);
        if (instituicao == null) {
            return NotFound("Instituição não encontrada.");
        }

        instituicao.Despesa += despesaDto.Despesa;
        _context.SaveChanges();

        return NoContent(); //retorna um status 204
    }


    [HttpGet("{id}")]
    public IActionResult GetInstituicaoPorId(int id) {
        var formInstituicao = _context.Instituicoes.FirstOrDefault(formInstituicao => formInstituicao.Id == id);
        if (formInstituicao == null) return NotFound();
        return Ok(formInstituicao);
    }

    [HttpGet]
    public IEnumerable<ReadInstituicaoDto> GetAllInstituicao() {
        var instituicoes = _context.Instituicoes
                                   .Include(i => i.Depositos)
                                   .Include(i => i.Debitos)
                                   .Include(i => i.FaturasCredito) 
                                   .ToList();
        return _mapper.Map<List<ReadInstituicaoDto>>(instituicoes);
    }

}