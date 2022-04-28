using SfPUT.Backend.Application.Interfaces.Rates;
using System;
using System.Linq;
using System.Threading.Tasks;
using SfPUT.Backend.Application.Interfaces.DataServices;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Services.Rates
{
    public class RateService : IRateService
    {
        private readonly IRateDataService _rateDataService;
        private readonly IPostDataService _postDataService;

        public RateService(IRateDataService rateDataService, IPostDataService psoDataService)
        {
            _rateDataService = rateDataService;
            _postDataService = psoDataService;
        }

        public async Task<bool> RatePost(Guid userId, Guid postId, int rate)
        {
            var post = await _postDataService.Get(postId);
            if (post == null)
            {
                return false;
            }
            if (userId != post.User.Id)
            {
                return false;
            }
            if (rate is < 0 or > 5)
            {
                return false;
            }
            var prevRate = (await _rateDataService.GetByUserId(userId))
                .FirstOrDefault(r => r.Post.Id == post.Id);
            if (prevRate == null)
            {
                var rateModel = new Rate()
                {
                    Id = Guid.NewGuid(),
                    Post = post,
                    UserId = userId,
                    Value = rate
                };

                await _rateDataService.Create(rateModel);
                return true;
            }

            prevRate.Value = rate;
            await _rateDataService.Update(prevRate.Id, prevRate);
            return true;
        }
    }
}
