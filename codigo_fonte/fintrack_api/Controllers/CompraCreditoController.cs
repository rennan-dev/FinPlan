using AutoMapper;
using fintrack_api.Data;
using fintrack_api.Dtos.CompraCredito;
using fintrack_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fintrack_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompraCreditoController : ControllerBase {

    private ApiContext _context;
    private IMapper _mapper;

    public CompraCreditoController(ApiContext context, IMapper mapper) {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> PostCompraCredito(CreateCompraCreditoDto dto) {
        // Validação dos dados
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Mapear o DTO para a entidade de CompraCredito
        var compraCredito = _mapper.Map<CompraCredito>(dto);

        // Buscar a Instituição para associar à compra
        var instituicao = await _context.Instituicoes
            .FirstOrDefaultAsync(i => i.Id == dto.InstituicaoId);
        if (instituicao == null)
        {
            return NotFound("Instituição não encontrada.");
        }

        // Adicionar a compra ao contexto
        _context.ComprasCredito.Add(compraCredito);
        await _context.SaveChangesAsync();

        // Criar a fatura com base na data de compra
        var mes = dto.DataCompra.Month.ToString("D2"); // Ex: 01, 02, ..., 12
        var ano = dto.DataCompra.Year.ToString();

        var fatura = new Fatura
        {
            Valor = dto.Valor,
            Mes = mes,
            Ano = ano,
            Pago = false, // Definido como não pago inicialmente
            InstituicaoId = dto.InstituicaoId
        };

        // Adicionar a fatura ao contexto
        _context.Faturas.Add(fatura);
        await _context.SaveChangesAsync();

        // Retornar resposta com os dados da compra de crédito e fatura criada
        return CreatedAtAction(nameof(PostCompraCredito), new { id = compraCredito.Id }, compraCredito);
    }

    [HttpGet]
    public async Task<IActionResult> GetTodasComprasCredito() {
        // Consulta para pegar todas as compras de crédito
        var comprasCredito = await _context.ComprasCredito
            .Include(cc => cc.Instituicao)  // Incluindo a instituição para retornar dados dela também
            .ToListAsync();

        // Se não encontrar nenhuma compra de crédito, retorna um 404
        if (!comprasCredito.Any())
        {
            return NotFound("Nenhuma compra de crédito encontrada.");
        }

        // Mapeando as compras de crédito para o DTO
        var comprasCreditoDto = _mapper.Map<List<ReadCompraCreditoDto>>(comprasCredito);

        // Retorna todas as compras de crédito
        return Ok(comprasCreditoDto);
    }
}