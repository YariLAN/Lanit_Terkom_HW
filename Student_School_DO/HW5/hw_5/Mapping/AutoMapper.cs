using AutoMapper;
using EntitiesEF;
using Models;

namespace RabbitServer.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Reader, ReaderModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Genre, GenreModel>().ReverseMap();
            CreateMap<Book,  BookModel>().ReverseMap();
            CreateMap<Issued, IssuedModel>().ReverseMap();
        }
    }
}
