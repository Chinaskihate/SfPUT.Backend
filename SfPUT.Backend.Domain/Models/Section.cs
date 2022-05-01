using System;
using System.Collections.Generic;

namespace SfPUT.Backend.Domain.Models
{
    public class Section : DomainObject
    {
        public string Name { get; set; }

        public Guid AdminId { get; set; }

        public List<Post> Posts { get; set; }
    }
}
