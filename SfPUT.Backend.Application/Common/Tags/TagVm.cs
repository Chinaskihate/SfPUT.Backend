using SfPUT.Backend.Application.Common.Mappings;
using SfPUT.Backend.Domain.Models;
using System;

namespace SfPUT.Backend.Application.Common.Tags
{
    public class TagVm : IMapWith<Tag>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
