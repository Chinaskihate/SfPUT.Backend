using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Domain.Models
{
    public class Comment : DomainObject
    {
        public string Content { get; set; }

        public Guid UserId { get; set; }

        public Post Post { get; set; }
    }
}
