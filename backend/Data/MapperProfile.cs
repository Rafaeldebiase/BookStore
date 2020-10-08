using AutoMapper;
using bookstore.domain.models;
using bookstore.dto;

namespace bookstore.data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<LivroDto, Livro>();
            CreateMap<Livro, LivroDto>();
        }
        
    }
}