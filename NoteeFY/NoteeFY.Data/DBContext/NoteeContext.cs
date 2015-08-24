using Microsoft.AspNet.Identity.EntityFramework;
using NoteeFY.Data.Models;

namespace NoteeFY.Data.DBContext
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base("name=IdentityContext")
        {
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}
