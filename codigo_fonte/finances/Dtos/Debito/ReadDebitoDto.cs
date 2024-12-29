namespace finances.Dtos.Debito; 
public class ReadDebitoDto {

    public int Id { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
}
