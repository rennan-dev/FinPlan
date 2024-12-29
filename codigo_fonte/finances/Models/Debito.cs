using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace finances.Models; 
public class Debito {

    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O valor da compra é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor da compra deve ser positivo.")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "A descrição da compra é obrigatória.")]
    [StringLength(100, ErrorMessage = "A descrição não pode ultrapassar 100 caracteres.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "A data da compra é obrigatória.")]
    [DataType(DataType.Date)]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "A instituição é obrigatória.")]
    public int InstituicaoId { get; set; }

    [ForeignKey("InstituicaoId")]
    [JsonIgnore]
    public Instituicao Instituicao { get; set; }
}
