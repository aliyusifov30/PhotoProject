using PhotoProject.Application.Repositories.PostFileRepositories;
using PhotoProject.Domain.Entities;
using PhotoProject.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoProject.Persistence.Repositories.PostFileRepositories
{
    public class PostFileReadRepository : ReadRepository<Post>, IPostFileReadRepository
    {
        public PostFileReadRepository(PhotoProjectContext context) : base(context)
        {
        }
    }
}
