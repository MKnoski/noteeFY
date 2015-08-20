using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using NoteeFY.Data.Models;

namespace NoteeFY.Data.DBContext
{
    public class NoteeContext : IdentityDbContext<ApplicationUser>
    {
        public NoteeContext()
            : base("NoteeContext", throwIfV1Schema: false)
        {
        }


        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<TaskItem> TaskItems { get; set; }
        public virtual DbSet<User> SubUsers { get; set; }

        public static NoteeContext Create()
        {
            return new NoteeContext();
        }
    }
}
