using System.ComponentModel.DataAnnotations;

namespace finances.Dtos.Instituicao;
public class CreateInstituicaoDto {
    [Required(ErrorMessage = "O nome da instituição é obrigatório.")]
    [StringLength(20, ErrorMessage = "O nome da instituição não pode ultrapassar 20 caracteres.")]
    public string Nome { get; set; }
}
