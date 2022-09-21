using PhotoProject.Domain.Common;
using PhotoProject.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }

        public PostFile PostFile { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
