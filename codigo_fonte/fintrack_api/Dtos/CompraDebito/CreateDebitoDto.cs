using System.ComponentModel.DataAnnotations;

namespace fintrack_api.Dtos.CompraDebito;
public class CreateCompraDebitoDto {

    [Required(ErrorMessage = "O valor da compra é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor da compra deve ser maior que 0.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "A descrição da compra é obrigatória.")]
    [StringLength(100, ErrorMessage = "A descrição não pode ultrapassar 100 caracteres.")]
    public required string Descricao { get; set; }

    [Required(ErrorMessage = "A instituição é obrigatória.")]
    public int InstituicaoId { get; set; }

    [Required]
    public DateTime DataCompra { get; set; } = DateTime.Now;
}