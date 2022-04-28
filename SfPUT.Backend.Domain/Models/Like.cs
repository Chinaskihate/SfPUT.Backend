using System;

namespace SfPUT.Backend.Domain.Models
{
    public class Like : DomainObject
    {
        public Guid PostId { get; set; }

        public Guid UserId { get; set; }
    }
}
