using System.ComponentModel.DataAnnotations;

namespace finances.Dtos.Deposito; 
public class CreateDepositoDto {

    [Required(ErrorMessage = "O valor do depósito é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor do depósito deve ser positivo.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "A descrição do depósito é obrigatória.")]
    [StringLength(100, ErrorMessage = "A descrição não pode ultrapassar 100 caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O identificador da instituição é obrigatório.")]
    public int InstituicaoId { get; set; }
}
