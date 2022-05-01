using SfPUT.Backend.Application.Common.Mappings;
using SfPUT.Backend.Domain.Models;
using System;
using AutoMapper;

namespace SfPUT.Backend.Application.Common.Tags
{
    public class TagVm : IMapWith<Tag>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Tag, TagVm>()
                .ForMember(vm => vm.Id, opt =>
                {
                    opt.MapFrom(t => t.Id);
                })
                .ForMember(vm => vm.Name, opt =>
                {
                    opt.MapFrom(t => t.Name);
                });
        }
    }
}
