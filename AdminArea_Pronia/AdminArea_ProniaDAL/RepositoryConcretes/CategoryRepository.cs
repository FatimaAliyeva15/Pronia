using AdminArea_ProniaCore.Models;
using AdminArea_ProniaCore.RepositoryAbstracts;
using AdminArea_ProniaData.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaData.RepositoryConcretes
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryReposiroty
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
