using NoteeFY.Data.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NoteeFY.Data.DBContext
{
    public class NoteeContext : DbContext
    {
        public NoteeContext() : base("NoteeContext"){}

        public DbSet<Note> Notes { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
