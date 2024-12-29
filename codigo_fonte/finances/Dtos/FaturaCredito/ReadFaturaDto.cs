using System.ComponentModel.DataAnnotations;

namespace finances.Dtos.FaturaCredito; 
public class ReadFaturaDto {

    public int Id { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; }
    public DateTime Data { get; set; }
    public int QuantidadeParcelas { get; set; }
    public int InstituicaoId { get; set; }
}
