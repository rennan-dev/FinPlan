using System.ComponentModel.DataAnnotations;

namespace finances.Dtos.FaturaCredito;

public class CreateFaturaDto {
    [Required(ErrorMessage = "O valor da compra é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor da compra deve ser positivo.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "A descrição da compra é obrigatória.")]
    [StringLength(100, ErrorMessage = "A descrição não pode ultrapassar 100 caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "A quantidade de parcelas é obrigatória.")]
    [Range(1, 120, ErrorMessage = "A quantidade de parcelas deve estar entre 1 e 120.")]
    public int QuantidadeParcelas { get; set; }

    [Required(ErrorMessage = "O identificador da instituição é obrigatório.")]
    public int InstituicaoId { get; set; }
}
