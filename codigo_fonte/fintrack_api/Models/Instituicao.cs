using System.ComponentModel.DataAnnotations;

namespace fintrack_api.Models;

public class Instituicao {

    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "O nome da instituição é obrigatório.")]
    [StringLength(20, ErrorMessage = "O nome da instituição não pode ultrapassar 20 caracteres.")]
    public required string Nome { get; set; }

    [Required] public decimal Saldo { get; set; }
    public required List<Fatura> Faturas { get; set; }
}