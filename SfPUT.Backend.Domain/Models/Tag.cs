using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Domain.Models
{
    public class Tag : DomainObject
    {
        public string Name { get; set; }

        public List<Post> Posts { get; set; }
    }
}
