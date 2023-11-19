using AutoMapper;
using EntitiesEF;
using Models;

namespace hw_5.Mapping
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
