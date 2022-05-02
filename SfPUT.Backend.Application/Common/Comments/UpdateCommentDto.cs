using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Common.Comments
{
    public class UpdateCommentDto
    {
        public string Content { get; set; }

        public Guid CommentId { get; set; }
    }
}
