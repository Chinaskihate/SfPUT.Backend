using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfPUT.Backend.Domain.Models
{
    public class PostInfo
    {
        public string Title { get; set; }

        public string SellerLink { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public DateTime LastEditTime { get; set; }
    }
}
