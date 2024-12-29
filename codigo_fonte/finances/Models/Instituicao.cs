using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace finances.Models;

public class Instituicao {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da instituição é obrigatório.")]
    [StringLength(20, ErrorMessage = "O nome da instituição não pode ultrapassar 20 caracteres.")]
    public string Nome { get; set; }

    public decimal Receita { get; set; } = 0;

    [Range(0, double.MaxValue, ErrorMessage = "A despesa deve ser um valor positivo.")]
    public decimal Despesa { get; set; } = 0;

    public decimal Total => Receita - Despesa;
    public virtual ICollection<FaturaCredito> FaturasCredito { get; set; } = new List<FaturaCredito>();
    [JsonIgnore]
    public virtual ICollection<Debito> Debitos { get; set; } = new List<Debito>();
    [JsonIgnore]
    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();
}
