using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Domain.Models
{
    public class Rate : DomainObject
    {
        public Guid UserId { get; set; }

        public int Value { get; set; }

        public Guid PostId { get; set; }

        public Post Post { get; set; }
    }
}
