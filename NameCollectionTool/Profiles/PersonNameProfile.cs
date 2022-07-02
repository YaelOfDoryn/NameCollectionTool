using AutoMapper;
using NameCollectionTool.Dtos;
using NameCollectionTool.Models;

namespace NameCollectionTool.Profiles
{
    public class PersonNameProfile : Profile
    {
        public PersonNameProfile()
        {
            CreateMap<PersonNameViewModel, PersonNameDto>().ReverseMap();
            CreateMap<PlaceNameViewModel, PlaceNameDto>().ReverseMap();
        }
    }
}
