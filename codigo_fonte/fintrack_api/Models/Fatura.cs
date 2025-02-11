using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace fintrack_api.Models;

public class Fatura {
    
    [Key] public int Id { get; set; }
    
    [Required(ErrorMessage = "O valor da compra é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor da fatura deve ser maior que 0.")]
    public decimal Valor { get; set; }
    
    [Required] public required string Mes { get; set; }
    [Required] public required string Ano { get; set; }
    [Required] public bool Pago { get; set; }
    
    //relacionamento com a Instituição
    [Required(ErrorMessage = "A instituição é obrigatória.")]
    public int InstituicaoId { get; set; }
    
    [ForeignKey("InstituicaoId")]
    [JsonIgnore]
    public Instituicao Instituicao { get; set; }
}