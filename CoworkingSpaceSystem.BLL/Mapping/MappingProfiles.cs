using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoworkingSpaceSystem.BLL.DTOs.SpaceDTOs;
using CoworkingSpaceSystem.DAL.Entities;
namespace CoworkingSpaceSystem.BLL.Mapping
   
{
    public class MappingProfiles:Profile

    {
        public MappingProfiles()
        {
            CreateMap<Space, SpaceToReturnDto>().ReverseMap();
            // CreateMap<SpaceCreateUpdateDto, SpaceViewModel>();
            //CreateMap<SpaceCreateUpdateDto, Space>();

            //CreateMap<SpaceCreateUpdateDto, Space>();

            // Mapping من Entity إلى DTO (لو محتاج)
           // CreateMap<Space, SpaceDtos>();

            // لو في Properties بأسماء مختلفة
            CreateMap<SpaceCreateUpdateDto, Space>()
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom(src => src.PictureUrl)).ReverseMap();

        }
    }
}
