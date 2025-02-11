using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fintrack_api.Models;

public class Deposito {

    [Key] public int Id { get; set; }
    
    [Required(ErrorMessage = "O valor do depósito é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor do depósito deve ser maior que 0.")]
     public decimal Valor { get; set; }
    
    [Required(ErrorMessage = "A data do depósito é obrigatória.")]
    [DataType(DataType.Date)]
     public DateTime DataDeposito { get; set; }
    
    [Required(ErrorMessage = "A descrição do depósito é obrigatório.")]
    [StringLength(100, ErrorMessage = "A descrição não pode ultrapassar 100 caracteres.")]
    public required string Descricao { get; set; }

    [Required(ErrorMessage = "A instituição é obrigatória.")]
    public int InstituicaoId { get; set; }

    [ForeignKey("InstituicaoId")]
    [JsonIgnore]
    public required Instituicao Instituicao { get; set; }
}