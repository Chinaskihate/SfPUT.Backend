using SfPUT.Backend.Application.Common.Mappings;
using SfPUT.Backend.Domain.Models;
using System;
using AutoMapper;

namespace SfPUT.Backend.Application.Common.Sections
{
    public class SectionVm : IMapWith<Section>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Section, SectionVm>()
                .ForMember(vm => vm.Id, opt =>
                    opt.MapFrom(s => s.Id))
                .ForMember(vm => vm.Name, opt =>
                    opt.MapFrom(s => s.Name));
        }
    }
}
