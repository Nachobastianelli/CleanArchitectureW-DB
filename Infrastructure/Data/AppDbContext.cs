using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }    
        public DbSet<ReviewMovie> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().
                HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<ReviewMovie>().
                HasOne(r => r.Movie).
                WithMany(a => a.Review).
                HasForeignKey(c => c.IdMovie);
        }
    }
}
