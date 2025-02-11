namespace fintrack_api.Dtos.Fatura;
public class ReadFaturaDto {

    public int Id { get; set; }
    public decimal Valor { get; set; }
    public required string Mes { get; set; }
    public required string Ano { get; set; }
    public bool Pago { get; set; }
    public int InstituicaoId { get; set; }
    public required string NomeInstituicao { get; set; }
}