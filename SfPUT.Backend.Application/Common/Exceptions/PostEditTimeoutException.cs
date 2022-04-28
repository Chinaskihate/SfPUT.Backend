using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Common.Exceptions
{
    public class PostEditTimeoutException : Exception
    {
        public PostEditTimeoutException(Guid postId, 
                                        DateTime creationDate, 
                                        DateTime currentTime)
        {
            PostId = postId;
            CreationDate = creationDate;
            CurrentTime = currentTime;
        }

        public PostEditTimeoutException(Guid postId,
            DateTime creationDate,
            DateTime currentTime,
            string message) : base(message)
        {
            PostId = postId;
            CreationDate = creationDate;
            CurrentTime = currentTime;
        }

        public Guid PostId { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime CurrentTime { get; set; }
    }
}
