using System;

namespace SfPUT.Backend.Application.Common.Exceptions
{
    public class PostAlreadyExistsException : Exception
    {
        public PostAlreadyExistsException(Guid userId, string title)
        {
            UserId = userId;
            Title = title;
        }

        public PostAlreadyExistsException(Guid userId, string title, string message) : base(message)
        {
            UserId = userId;
            Title = title;
        }

        public PostAlreadyExistsException(Guid userId, string title, string message, Exception innerException) : base(message, innerException)
        {
            UserId = userId;
            Title = title;
        }

        public Guid UserId { get; set; }

        public string Title { get; set; }
    }
}
