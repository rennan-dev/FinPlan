using fintrack_api.Dtos.Fatura;

namespace fintrack_api.Dtos.Instituicao;

public class ReadInstituicaoDto {

    public int Id { get; set; }
    public required string Nome { get; set; }
    public decimal Saldo { get; set; }
    public required List<ReadFaturaDto> Faturas { get; set; }
}