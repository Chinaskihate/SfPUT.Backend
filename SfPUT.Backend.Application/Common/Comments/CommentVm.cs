using System;
using AutoMapper;
using SfPUT.Backend.Application.Common.Mappings;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Common.Comments
{
    public class CommentVm : IMapWith<Comment>
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string Username { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Comment, CommentVm>()
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(com => com.Id))
                .ForMember(vm => vm.Content,
                    opt => opt.MapFrom(com => com.Info.Content))
                .ForMember(vm => vm.Username,
                    opt => opt.MapFrom(com => com.User.Username));
        }
    }
}
