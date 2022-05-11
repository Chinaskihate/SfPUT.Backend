using System;

namespace SfPUT.Backend.Domain.Models
{
    public class CommentInfo
    {
        public string Content { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastEditTime { get; set; }
    }
}
