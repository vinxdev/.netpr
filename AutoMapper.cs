using AutoMapper;
using studentcrud.DTOS;
using studentcrud.Models;

namespace studentcrud
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentsDTO, Student>();
            CreateMap<CoursesDTO, Course>();
        }
    }
}