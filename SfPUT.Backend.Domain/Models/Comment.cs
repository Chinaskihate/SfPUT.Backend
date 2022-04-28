namespace SfPUT.Backend.Domain.Models
{
    public class Comment : DomainObject
    {
        public CommentInfo Info { get; set; }

        public User User { get; set; }

        public Post Post { get; set; }
    }
}
