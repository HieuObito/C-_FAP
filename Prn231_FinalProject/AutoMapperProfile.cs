using AutoMapper;
using Prn231_FinalProject.DTO;
using Prn231_FinalProject.Models;
using System.IO;

namespace Prn231_FinalProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentClass, StudentClassDTO>()
                .ReverseMap();
        }
    }
}
