using NoteeFY.Data.Models;
using System.Data.Entity;

namespace NoteeFY.Data.DBContext
{
    public class NoteeContext : DbContext
    {
        public NoteeContext()
            : base("NoteeContext")
        {
            
        }

        static NoteeContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NoteeContext>());
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
