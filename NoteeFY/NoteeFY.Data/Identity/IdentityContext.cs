using Microsoft.AspNet.Identity.EntityFramework;

namespace NoteeFY.Data.Identity
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
