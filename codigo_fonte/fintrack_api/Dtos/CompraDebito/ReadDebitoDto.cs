namespace fintrack_api.Dtos.CompraDebito;
public class ReadCompraDebitoDto {
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataCompra { get; set; }
    public required string Descricao { get; set; }
    public int InstituicaoId { get; set; }
    public required string NomeInstituicao { get; set; }      
}
