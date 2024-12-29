using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finances.Models;

public class FaturaCredito {
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

    [Required(ErrorMessage = "A quantidade de parcelas é obrigatória.")]
    [Range(1, 120, ErrorMessage = "A quantidade de parcelas deve estar entre 1 e 120.")]
    public int QuantidadeParcelas { get; set; }

    [Required(ErrorMessage = "A instituição é obrigatória.")]
    public int InstituicaoId { get; set; }

    [ForeignKey("InstituicaoId")]
    public Instituicao Instituicao { get; set; }
}
