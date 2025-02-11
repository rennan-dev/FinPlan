using AutoMapper;
using fintrack_api.Dtos.Instituicao;
using fintrack_api.Dtos.CompraCredito;
using fintrack_api.Dtos.CompraDebito;
using fintrack_api.Dtos.Deposito;
using fintrack_api.Dtos.Fatura;
using fintrack_api.Models;

namespace fintrack_api.Profiles;
public class ApiProfile : Profile {
    public ApiProfile() {

        CreateMap<CreateInstituicaoDto, Instituicao>()
            .ReverseMap(); 
        
        CreateMap<Instituicao, ReadInstituicaoDto>()
            .ReverseMap(); 

        CreateMap<CreateDepositoDto, Deposito>()
            .ReverseMap(); 
        
        CreateMap<Deposito, ReadDepositoDto>()
        .ForMember(dest => dest.NomeInstituicao, opt => opt.MapFrom(src => src.Instituicao.Nome))
            .ReverseMap(); 
        
        CreateMap<CreateCompraDebitoDto, CompraDebito>()
            .ReverseMap(); 

        CreateMap<CompraDebito, ReadCompraDebitoDto>()
        .ForMember(dest => dest.NomeInstituicao, opt => opt.MapFrom(src => src.Instituicao.Nome))
            .ReverseMap(); 
        
        CreateMap<CreateCompraCreditoDto, CompraCredito>()
            .ReverseMap(); 

        CreateMap<CompraCredito, ReadCompraCreditoDto>()
            .ForMember(dest => dest.NomeInstituicao, opt => opt.MapFrom(src => src.Instituicao.Nome))
            .ReverseMap(); 
        
        CreateMap<CreateFaturaDto, Fatura>()
            .ReverseMap(); 

        CreateMap<Fatura, ReadFaturaDto>()
            .ForMember(dest => dest.NomeInstituicao, opt => opt.MapFrom(src => src.Instituicao.Nome))
            .ReverseMap(); 
    }
}