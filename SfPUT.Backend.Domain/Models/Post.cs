using System.Collections.Generic;

namespace SfPUT.Backend.Domain.Models
{
    public class Post : DomainObject
    {
        public User User { get; set; }

        public Section Section { get; set; }

        public PostInfo Info { get; set; }

        public List<Comment> Comments { get; set; } 

        public List<Rate> Rates { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
