using System.Linq;
using GogoWeb.API.Context;
using GogoWeb.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GogoWeb.API.Seeds
{

    public static class InitialData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppWebContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppWebContext>>()))
            {
                if (context.Users.Any())
                {
                    return;   // DB has been seeded
                }

                context.Users.AddRange(
                    new User
                    {
                        UserName = "admin",
                        Nationality = "French",
                        Email = "admin@gmail.com",
                        Password = "password"
                    }, new User
                    {
                        UserName = "user",
                        Nationality = "English",
                        Email = "user@gmail.com",
                        Password = "password"
                    }
                    // add more seed data as needed
                );

                context.SaveChanges();
            }
        }
      
    }
}
