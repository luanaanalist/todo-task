
using AutoMapper;
using ToDoApp.Application.ViewModel;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemTask, ItemTaskVM>().ReverseMap();
        }
    }
}
