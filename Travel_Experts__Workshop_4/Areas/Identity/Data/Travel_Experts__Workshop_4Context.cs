using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Travel_Experts__Workshop_4.Areas.Identity.Data;

namespace Travel_Experts__Workshop_4.Data
{
    public class Travel_Experts__Workshop_4Context : IdentityDbContext<Travel_Experts__Workshop_4User>
    {
        public Travel_Experts__Workshop_4Context(DbContextOptions<Travel_Experts__Workshop_4Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
