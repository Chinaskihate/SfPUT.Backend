using System;

namespace SfPUT.Backend.Application.Common.Comments
{
    public class CreateCommentDto
    {
        public string Content { get; set; }
        
        public Guid PostId { get; set; }
    }
}
