using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    public class SimpleBlog2Context : DbContext
    {
        public SimpleBlog2Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ArticleModel> Articles { get; set; }
        public DbSet<ArticleCategoryModel> ArticleCategories { get; set; }
    }
}
