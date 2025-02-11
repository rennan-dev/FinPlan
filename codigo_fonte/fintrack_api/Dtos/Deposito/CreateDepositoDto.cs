using System.ComponentModel.DataAnnotations;

namespace fintrack_api.Dtos.Deposito;
public class CreateDepositoDto {

    [Required(ErrorMessage = "O valor do depósito é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor do depósito deve ser maior que 0.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "A descrição do depósito é obrigatória.")]
    [StringLength(100, ErrorMessage = "A descrição não pode ultrapassar 100 caracteres.")]
    public required string Descricao { get; set; }

    [Required(ErrorMessage = "A instituição é obrigatória.")]
    public int InstituicaoId { get; set; }

    [Required]
    public DateTime DataDeposito { get; set; } = DateTime.Now;
}
