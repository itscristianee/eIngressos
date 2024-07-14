using eIngressos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eIngressos.Data
{
    public static class UserRoles
    {
        public const string Admin = "Admin";
        public const string Client = "Client";
    }

    public class AppDbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());
            context.Database.EnsureCreated();

            // Seed actors
            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actors>
                {
                    new Actors { Name = "Actor 1", Bio = "This is the Bio of the first actor", Photo = "http://dotnethow.net/images/actors/actor-1.jpeg", ActedIns = new List<ActedIn>() },
                    new Actors { Name = "Actor 2", Bio = "This is the Bio of the second actor", Photo = "http://dotnethow.net/images/actors/actor-2.jpeg", ActedIns = new List<ActedIn>() },
                    new Actors { Name = "Actor 3", Bio = "This is the Bio of the third actor", Photo = "http://dotnethow.net/images/actors/actor-3.jpeg", ActedIns = new List<ActedIn>() },
                    new Actors { Name = "Actor 4", Bio = "This is the Bio of the fourth actor", Photo = "http://dotnethow.net/images/actors/actor-4.jpeg", ActedIns = new List<ActedIn>() },
                    new Actors { Name = "Actor 5", Bio = "This is the Bio of the fifth actor", Photo = "http://dotnethow.net/images/actors/actor-5.jpeg", ActedIns = new List<ActedIn>() }
                });
                context.SaveChanges();
            }

            // Seed movies
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movies>
                {
                    new Movies { Title = "Life", Description = "This is the Life movie description", Price = 39.50m, Image = "http://dotnethow.net/images/movies/movie-3.jpeg", Duration = 120, AgeRating = 12, Producer = "Producer 3", Category = eIngressos.Data.Enums.MovieCategory.Documentary, Actors = new List<ActedIn>() },
                    new Movies { Title = "The Shawshank Redemption", Description = "This is the Shawshank Redemption description", Price = 29.50m, Image = "http://dotnethow.net/images/movies/movie-1.jpeg", Duration = 142, AgeRating = 15, Producer = "Producer 1", Category = eIngressos.Data.Enums.MovieCategory.Action, Actors = new List<ActedIn>() }
                });
                context.SaveChanges();
            }

            // Seed ActedIn relationships
            if (!context.ActedIns.Any())
            {
                var actor1 = context.Actors.FirstOrDefault(a => a.Name == "Actor 1");
                var actor3 = context.Actors.FirstOrDefault(a => a.Name == "Actor 3");
                var movie1 = context.Movies.FirstOrDefault(m => m.Title == "Life");

                context.ActedIns.AddRange(new List<ActedIn>
                {
                    new ActedIn { Actor = actor1, Movie = movie1, Character = "Main Character", Role = "Lead" },
                    new ActedIn { Actor = actor3, Movie = movie1, Character = "Supporting Character", Role = "Support" }
                });
                context.SaveChanges();
            }

            // Seed theaters
            if (!context.Theaters.Any())
            {
                context.Theaters.AddRange(new List<Theaters>
                {
                    new Theaters { Name = "Theater 1", Capacity = 100, Sessions = new List<Sessions>() },
                    new Theaters { Name = "Theater 2", Capacity = 150, Sessions = new List<Sessions>() }
                });
                context.SaveChanges();
            }

            // Seed sessions
            if (!context.Sessions.Any())
            {
                context.Sessions.AddRange(new List<Sessions>
                {
                    new Sessions { TheaterId = 1, MovieId = 1, SessionDateTime = DateTime.Now.AddHours(1), Tickets = new List<Tickets>() },
                    new Sessions { TheaterId = 2, MovieId = 2, SessionDateTime = DateTime.Now.AddHours(2), Tickets = new List<Tickets>() }
                });
                context.SaveChanges();
            }

            // Seed tickets
            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(new List<Tickets>
                {
                    new Tickets { Sold = true, Quantity = 2, Total = 59.00m, PurchaseDate = DateTime.Now, SessionId = 1, UserTickets = new List<UserTickets>() },
                    new Tickets { Sold = false, Quantity = 1, Total = 29.50m, PurchaseDate = DateTime.Now, SessionId = 2, UserTickets = new List<UserTickets>() }
                });
                context.SaveChanges();
            }

            // Seed user tickets
            if (!context.UserTickets.Any())
            {
                var userManager = serviceProvider.GetRequiredService<UserManager<UsersApp>>();

                var user1 = userManager.FindByNameAsync("app-user").Result;
                var user2 = userManager.FindByNameAsync("another-user").Result;

                context.UserTickets.AddRange(new List<UserTickets>
                {
                    new UserTickets { Name = user1.Id, TicketId = 1 },
                    new UserTickets { Name = user2.Id, TicketId = 2 }
                });
                context.SaveChanges();
            }
        }

        public static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.CreateScope();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Seed roles
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.Client))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Client));

            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<UsersApp>>();

            // Seed users
            string adminUserEmail = "admin@eIngressos.com";
            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new UsersApp
                {
                    Name = "Admin User",
                    UserName = "admin-user",
                    Email = adminUserEmail,
                    EmailConfirmed = true,
                    UserTickets = new List<UserTickets>()
                };
                await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }

            string appUserEmail = "user@eIngressos.com";
            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new UsersApp
                {
                    Name = "Client User",
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true,
                    UserTickets = new List<UserTickets>()
                };
                await userManager.CreateAsync(newAppUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.Client);
            }

            string anotherUserEmail = "anotheruser@eIngressos.com";
            var anotherUser = await userManager.FindByEmailAsync(anotherUserEmail);
            if (anotherUser == null)
            {
                var newAnotherUser = new UsersApp
                {
                    Name = "Another User",
                    UserName = "another-user",
                    Email = anotherUserEmail,
                    EmailConfirmed = true,
                    UserTickets = new List<UserTickets>()
                };
                await userManager.CreateAsync(newAnotherUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newAnotherUser, UserRoles.Client);
            }
        }
    }
}
