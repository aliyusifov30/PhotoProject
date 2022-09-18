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
    public class TagWriteRepository : WriteRepository<Tag>, ITagWriteRepository
    {
        public TagWriteRepository(PhotoProjectContext context) : base(context)
        {
        }
    }
}
