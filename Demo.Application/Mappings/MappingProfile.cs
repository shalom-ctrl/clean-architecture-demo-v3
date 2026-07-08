using AutoMapper;
using Demo.Application.Features.Product.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateProductCommand, Demo.Domain.Entities.Product>()
                .ForMember(destination => destination.Description, source => source.MapFrom(s => s.Remarks)).ReverseMap();
        }
    }
}
