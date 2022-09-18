using PhotoProject.Application.Repositories.TagRepositories;
using PhotoProject.Domain;
using PhotoProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence.Repositories.TagRepositories
{
    public class TagReadRepository : ReadRepository<Tag>, ITagReadRepository
    {
        public TagReadRepository(PhotoProjectContext context) : base(context)
        {
        }
    }
}
