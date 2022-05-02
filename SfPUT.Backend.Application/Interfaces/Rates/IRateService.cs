using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SfPUT.Backend.Application.Common.Rates;
using SfPUT.Backend.Domain.Models;

namespace SfPUT.Backend.Application.Interfaces.Rates
{
    public interface IRateService
    {
        Task<bool> RatePost(RatePostDto dto, Guid userId);
        Task<IEnumerable<Rate>> GetUserRates(Guid userId);
    }
}
