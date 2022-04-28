using System;
using System.ComponentModel.DataAnnotations;

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
