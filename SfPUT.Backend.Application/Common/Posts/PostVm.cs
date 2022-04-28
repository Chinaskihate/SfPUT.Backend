using AutoMapper;
using SfPUT.Backend.Application.Common.Comments;
using SfPUT.Backend.Application.Common.Mappings;
using SfPUT.Backend.Application.Common.Sections;
using SfPUT.Backend.Application.Common.Tags;
using SfPUT.Backend.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace SfPUT.Backend.Application.Common.Posts
{
    public class PostVm : IMapWith<Post>
    {
        public SectionVm Section { get; set; }

        public PostInfo Info { get; set; }

        public IEnumerable<CommentVm> Comments { get; set; }

        public double Rate { get; set; }

        public IEnumerable<TagVm> Tags { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostVm>()
                .ForMember(vm => vm.Section,
                    opt => opt.MapFrom(post => post.Section))
                .ForMember(dto => dto.Rate, 
                    opt => opt.MapFrom(post => post.Rates.Count == 0 
                        ? 0 
                        : post.Rates.Average(r => r.Value)))
                .AfterMap((post, postVm, context) =>
                {
                    postVm.Section = context.Mapper.Map<SectionVm>(Section);
                    postVm.Comments = post.Comments.Select(c => context.Mapper.Map<CommentVm>(c));
                    postVm.Tags = post.Tags.Select(t => context.Mapper.Map<TagVm>(t));
                });
        }
    }
}
