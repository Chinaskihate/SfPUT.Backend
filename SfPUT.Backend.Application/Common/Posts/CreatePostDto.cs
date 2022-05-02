using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Common.Posts
{
    public class CreatePostDto
    {
        public Guid SectionId { get; set; }

        public string Title { get; set; }

        public string SellerLink { get; set; }

        public string Description { get; set; }
        
        public IEnumerable<Guid> TagsIds { get; set; }
    }
}
