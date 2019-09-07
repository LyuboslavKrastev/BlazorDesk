using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorDesk.Server.Data
{
    /* Because we are using Identity which needs to store information in a database 
        we're not inheriting from DbContext but instead from IdentityDbContext.  
        The IdentityDbContext base class contains all the configuration EF needs to manage the Identity database tables. */
    public class BlazorDeskDbContext : IdentityDbContext
    {
        public BlazorDeskDbContext(DbContextOptions options) : base(options)
        {
        }


    }
}
