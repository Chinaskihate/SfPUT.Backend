using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Common.Posts
{
    public class GetPostDto
    {
        public string Title { get; set; }

        public IEnumerable<Guid> TagsIds { get; set; }
        
        public double MinRate { get; set; }
        
        public Guid SectionId { get; set; }
        
        public DateTime CreationTime { get; set; }
    }
}
