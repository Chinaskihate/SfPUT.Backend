using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Common.Rates
{
    public class RatePostDto
    {
        public Guid PostId { get; set; }

        public int Rate { get; set; }
    }
}
