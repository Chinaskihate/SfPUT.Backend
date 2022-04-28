using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Application.Common.Exceptions
{
    public class SectionNotFoundException : Exception
    {
        public SectionNotFoundException(Guid id, string name = null)
        {
            Id = id;
            Name = name;
        }

        public SectionNotFoundException(string name)
        {
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
