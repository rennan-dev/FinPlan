using System.ComponentModel.DataAnnotations;

namespace finances.Dtos.Instituicao; 
public class UpdateSaldoDto {

    public decimal Receita { get; set; } = 0;
}
