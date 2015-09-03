namespace QuizOPoll.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using QuizOPoll.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<QuizOPoll.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(QuizOPoll.Models.ApplicationDbContext context)
        {
            // Seed with admin role
            //-------------------------------------------------------------------------------
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin", Email="admin@admin.com", EmailConfirmed=true };

                manager.Create(user, "password");
                manager.AddToRole(user.Id, "admin");
            }
        }
    }
}
