using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.Rates
{
    public interface IRateService
    {
        Task<bool> RatePost(Guid userId, Guid postId, int rate);
        Task<IEnumerable<Rate>> GetUserRates(Guid userId);
    }
}
