using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SfPUT.Backend.Application.Interfaces;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Persistence.DataServices;

namespace SfPUT.Backend.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICommentDataService, CommentDataService>();
            services.AddScoped<ILikeDataService, LikeDataService>();
            services.AddScoped<IPostDataService, PostDataService>();
            services.AddScoped<IProposedSectionDataService, ProposedSectionDataService>();
            services.AddScoped<IRateDataService, RateDataService>();
            services.AddScoped<ISectionDataService, SectionDataService>();
            services.AddScoped<ITagDataService, TagDataService>();

            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(connectionString);
                options.EnableSensitiveDataLogging();
            });
            services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());
            return services;
        }
    }
}
