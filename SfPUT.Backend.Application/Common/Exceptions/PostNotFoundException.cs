using System;

namespace SfPUT.Backend.Application.Common.Exceptions
{
    public class PostNotFoundException : Exception
    {
        public PostNotFoundException(Guid postId)
        {
            PostId = postId;
        }

        public PostNotFoundException(Guid postId, string message) : base(message)
        {
            PostId = postId;
        }

        public PostNotFoundException(Guid postId, string message, Exception innerException) : base(message, innerException)
        {
            PostId = postId;
        }

        public Guid PostId { get; set; }
    }
}
