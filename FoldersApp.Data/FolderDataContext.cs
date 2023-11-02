using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldersApp.Data
{
    public class FolderDataContext : DbContext
    {
        public FolderDataContext(DbContextOptions<FolderDataContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        public FolderDataContext() :base()
        {
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Database=FoldersDB;Port=5432;User Id=postgres;Password=l'horizon");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Folder> Folders { get; set;}
        public DbSet<FolderLink> FolderLinks { get; set;}
    }
}
