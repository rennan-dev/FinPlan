using AutoMapper;
using finances.Dtos.Debito;
using finances.Dtos.Deposito;
using finances.Dtos.FaturaCredito;
using finances.Dtos.Instituicao;
using finances.Models;

public class InstituicaoProfile : Profile {

    public InstituicaoProfile() {
        CreateMap<CreateInstituicaoDto, Instituicao>();

        //mapeando as Instituições para ReadInstituicaoDto e incluindo as faturas
        CreateMap<Instituicao, ReadInstituicaoDto>()
            .ForMember(dest => dest.Despesa, opt => opt.MapFrom(src =>
                src.FaturasCredito.Sum(f => f.Valor))) //soma os valores de crédito para calcular a despesa
            .ForMember(dest => dest.Faturas, opt => opt.MapFrom(src => src.FaturasCredito)) //inclui as faturas de crédito no DTO
            .ForMember(dest => dest.Debitos, opt => opt.MapFrom(src => src.Debitos)) //inclui os débitos no DTO
            .ForMember(dest => dest.Depositos, opt => opt.MapFrom(src => src.Depositos)); //inclui os depositos no dto
        CreateMap<ReadInstituicaoDto, Instituicao>();

        //faturas
        CreateMap<CreateFaturaDto, FaturaCredito>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<FaturaCredito, ReadFaturaDto>();

        //debitos
        CreateMap<CreateDebitoDto, Debito>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<Debito, ReadDebitoDto>();

        //depositos
        CreateMap<CreateDepositoDto, Deposito>()
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => DateTime.Now));
        CreateMap<Deposito, ReadDepositoDto>();
    }
}
