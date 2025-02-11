using System.ComponentModel.DataAnnotations;

namespace fintrack_api.Dtos.Fatura;
public class CreateFaturaDto {

    [Required(ErrorMessage = "O valor da fatura é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor da fatura deve ser maior que 0.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "O mês da fatura é obrigatório.")]
    [StringLength(2, ErrorMessage = "O mês deve ter 2 caracteres.")]
    public required string Mes { get; set; }

    [Required(ErrorMessage = "O ano da fatura é obrigatório.")]
    [StringLength(4, ErrorMessage = "O ano deve ter 4 caracteres.")]
    public required string Ano { get; set; }

    [Required(ErrorMessage = "O status de pagamento da fatura é obrigatório.")]
    public bool Pago { get; set; }

    [Required(ErrorMessage = "A instituição é obrigatória.")]
    public int InstituicaoId { get; set; }
}