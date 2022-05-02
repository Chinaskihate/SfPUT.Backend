using SfPUT.Backend.Application.Interfaces.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SfPUT.Backend.Application.Common.Rates;
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

        public async Task<bool> RatePost(RatePostDto dto, Guid userId)
        {
            var post = await _postDataService.Get(dto.PostId);
            if (post == null)
            {
                return false;
            }
            if (userId != post.User.Id)
            {
                return false;
            }
            if (dto.Rate is < 0 or > 5)
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
                    Value = dto.Rate
                };

                await _rateDataService.Create(rateModel);
                return true;
            }

            prevRate.Value = dto.Rate;
            await _rateDataService.Update(prevRate.Id, prevRate);
            return true;
        }

        public async Task<IEnumerable<Rate>> GetUserRates(Guid userId)
        {
            var rates = await _rateDataService.GetByUserId(userId);
            return await rates.ToListAsync();
        }
    }
}
