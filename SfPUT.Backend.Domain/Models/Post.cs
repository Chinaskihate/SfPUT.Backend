using System;
using System.Collections.Generic;

namespace SfPUT.Backend.Domain.Models
{
    public class Post : DomainObject
    {
        public Guid UserId { get; set; }

        public Guid SectionId { get; set; }

        public Section Section { get; set; }

        public string Title { get; set; }

        public string SellerLink { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastEditTime { get; set; }

        public List<Comment> Comments { get; set; } 

        public List<Rate> Rates { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
