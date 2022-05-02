using System;
using System.Collections.Generic;

namespace SfPUT.Backend.Application.Common.Posts
{
    public class UpdatePostDto
    {
        public Guid PostId { get; set; }
        
        public string SellerLink { get; set; }

        public string Description { get; set; }

        public IEnumerable<Guid> TagsIds { get; set; }
    }
}
