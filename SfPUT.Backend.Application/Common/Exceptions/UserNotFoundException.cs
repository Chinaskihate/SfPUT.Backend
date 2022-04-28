using System;

namespace SfPUT.Backend.Application.Common.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(Guid id, string username = "")
        {
            Id = id;
            Username = username;
        }

        public UserNotFoundException(Guid id, string message, string username = "") : base(message)
        {
            Id = id;
            Username = username;
        }

        public UserNotFoundException(Guid id, string message, 
            Exception innerException, string username = "") : base(message, innerException)
        {
            Id = id;
            Username = username;
        }

        public Guid Id { get; set; }

        public string Username { get; set; }
    }
}
