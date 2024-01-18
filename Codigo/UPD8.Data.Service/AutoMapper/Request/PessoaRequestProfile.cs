using AutoMapper;
using UPD8.Data.Domain.DTOs.Request;
using UPD8.Data.Domain.Entity;

namespace UPD8.Data.Service.AutoMapper.Request
{
    public class PessoaRequestProfile : Profile
    {
        public PessoaRequestProfile()
        {
            CreateMap<PessoaRequestDTO, PessoaEntity>();
        }
    }
}
