using System.Collections.Generic;

namespace SfPUT.Backend.Domain.Models
{
    public class Tag : DomainObject
    {
        public string Name { get; set; }

        public List<Post> Posts { get; set; }

        public override bool Equals(object tag)
        {
            if (tag is Tag otherTag)
            {
                return Id == otherTag.Id && Name == otherTag.Name;
            }

            return false;
        }

        public static bool operator ==(Tag firstTag, Tag secondTag)
        {
            return firstTag != null && firstTag.Equals(secondTag);
        }

        public static bool operator !=(Tag firstTag, Tag secondTag)
        {
            return firstTag != null && !firstTag.Equals(secondTag);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + Name.GetHashCode();
        }
    }
}
