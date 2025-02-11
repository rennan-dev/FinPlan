using AutoMapper;
using fintrack_api.Data;
using fintrack_api.Dtos.Instituicao;
using fintrack_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fintrack_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InstituicaoController : ControllerBase {

    private ApiContext _context;
    private IMapper _mapper;

    public InstituicaoController(ApiContext context, IMapper mapper) {
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

    [HttpGet("{id}")]
    public IActionResult GetInstituicaoPorId(int id) {
        var formInstituicao = _context.Instituicoes.
            Include(i=>i.Faturas).
            FirstOrDefault(formInstituicao => formInstituicao.Id == id);
        if (formInstituicao == null) return NotFound();
        return Ok(formInstituicao);
    }

    [HttpGet]
    public IEnumerable<ReadInstituicaoDto> GetAllInstituicao() {
        var instituicoes = _context.Instituicoes
                                   .Include(i=>i.Faturas)
                                   .ToList();
        return _mapper.Map<List<ReadInstituicaoDto>>(instituicoes);
    }

}