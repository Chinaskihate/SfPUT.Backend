using System;

namespace SfPUT.Backend.Application.Common.Exceptions
{
    public class EditingNotUserOwnPostException : Exception
    {
        public Guid UserId { get; set; }

        public Guid PostId { get; set; }

        public EditingNotUserOwnPostException(Guid userId, Guid postId)
        {
            UserId = userId;
            PostId = postId;
        }

        public EditingNotUserOwnPostException(Guid userId, Guid postId, string message) : base(message)
        {
            UserId = userId;
            PostId = postId;
        }

        public EditingNotUserOwnPostException(Guid userId, Guid postId, string message, Exception innerException) : base(message, innerException)
        {
            UserId = userId;
            PostId = postId;
        }
    }
}
