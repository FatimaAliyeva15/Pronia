using AdminArea_ProniaCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaData.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        {
            
        }

        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<ProductPhoto> ProductPhotos { get; set; }
        DbSet<Slider> Sliders { get; set; }
    }
}
