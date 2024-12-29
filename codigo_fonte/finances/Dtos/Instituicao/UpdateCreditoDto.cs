using System.ComponentModel.DataAnnotations;

namespace finances.Dtos.Instituicao; 
public class UpdateCreditoDto {

    [Range(0, double.MaxValue, ErrorMessage = "A despesa deve ser um valor positivo.")]
    public decimal Despesa { get; set; } = 0;
}
