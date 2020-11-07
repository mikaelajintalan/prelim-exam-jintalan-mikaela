using Microsoft.EntityFrameworkCore;
using prelim_exam_jintalan_mikaela.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prelim_exam_jintalan_mikaela.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }

    }
}