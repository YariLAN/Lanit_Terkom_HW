using AutoMapper;
using EntitiesEF;
using Models;

namespace RabbitServer.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Reader, ReaderInfo>().ReverseMap();
            CreateMap<Category, CategoryInfo>().ReverseMap();
            CreateMap<Genre, GenreInfo>().ReverseMap();
            CreateMap<Book,  BookInfo>().ReverseMap();
            CreateMap<Issued, IssuedInfo>().ReverseMap();
        }
    }
}
