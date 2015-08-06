using NoteeFY.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NoteeFY.Data.DBContext
{
    public class NoteeContext : DbContext
    {
        public NoteeContext() : base("NoteeContext"){}

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
