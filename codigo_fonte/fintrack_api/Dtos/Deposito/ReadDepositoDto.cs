namespace fintrack_api.Dtos.Deposito;
public class ReadDepositoDto {
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataDeposito { get; set; }
    public required string Descricao { get; set; }
    public int InstituicaoId { get; set; }
    public required string NomeInstituicao { get; set; }
}