using finances.Dtos.Debito;
using finances.Dtos.Deposito;
using finances.Dtos.FaturaCredito;

namespace finances.Dtos.Instituicao {
    public class ReadInstituicaoDto {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Receita { get; set; }
        public decimal Despesa { get; set; }
        public decimal Total { get; set; }
        public ICollection<ReadFaturaDto> Faturas { get; set; } // Lista de faturas associadas
        public ICollection<ReadDebitoDto> Debitos { get; set; } // Lista de debitos associadas
        public ICollection<ReadDepositoDto> Depositos { get; set; } // Lista de depositos associadas
    }
}
