using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SfPUT.Backend.Application.Interfaces.Comments;
using SfPUT.Backend.Application.Interfaces.Likes;
using SfPUT.Backend.Application.Interfaces.Posts;
using SfPUT.Backend.Application.Interfaces.Rates;
using SfPUT.Backend.Application.Interfaces.Sections;
using SfPUT.Backend.Application.Interfaces.Tags;
using SfPUT.Backend.Application.Interfaces.Users;
using SfPUT.Backend.Application.Services.Comments;
using SfPUT.Backend.Application.Services.Likes;
using SfPUT.Backend.Application.Services.Posts;
using SfPUT.Backend.Application.Services.Rates;
using SfPUT.Backend.Application.Services.Sections;
using SfPUT.Backend.Application.Services.Tags;

namespace SfPUT.Backend.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IRateService, RateService>();
            services.AddScoped<ISectionService, SectionService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<IUserService, IUserService>();

            return services;
        }
    }
}
