using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Domain.Models
{
    public class Rate : DomainObject
    {
        public Guid UserId { get; set; }

        [Range(0, 5)]
        public int Value { get; set; }

        public Post Post { get; set; }
    }
}
