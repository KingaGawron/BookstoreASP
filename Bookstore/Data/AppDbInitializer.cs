using Bookstore.Data.Static;
using Bookstore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviseScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviseScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                
                //PublishingHouse
                if (!context.PublishingHouses.Any())
                {
                    context.PublishingHouses.AddRange(new List<PublishingHouse>()
                    {
                        new PublishingHouse()
                        {
                            Name = "Filia",
                            LogoURL = "https://s.lubimyczytac.pl/upload/publishers/2918/2918-b.jpg",
                            Description = "This is the description of the first publishing house"
                        },
                        new PublishingHouse()
                        {
                            Name = "Albatros",
                            LogoURL = "https://s.lubimyczytac.pl/upload/publishers/417/417-b.jpg",
                            Description = "This is the description of the secend publishing house"
                        },
                        new PublishingHouse()
                        {
                            Name = "MANDO",
                            LogoURL = "https://s.lubimyczytac.pl/upload/publishers/19215/19215-b.jpg",
                            Description = "This is the description of the third publishing house"
                        },
                        new PublishingHouse()
                        {
                            Name = "We need YA",
                            LogoURL = "https://s.lubimyczytac.pl/upload/publishers/21409/21409-b.jpg",
                            Description = "This is the description of the fourth publishing house"
                        },
                        new PublishingHouse()
                        {
                            Name = "Mag",
                            LogoURL = "https://s.lubimyczytac.pl/upload/publishers/5382/5382-b.jpg",
                            Description = "This is the description of the fifth publishing house"
                        },
                    });
                    context.SaveChanges();
                }
                //Author
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                        new Author()
                        {
                            FullName = "Remigiusz Mróz",
                            Bio = "This is the Bio of the first author",
                            ProfilePictureURL = "https://s.lubimyczytac.pl/upload/authors/82094/914988-352x500.jpg"

                        },
                        new Author()
                        {
                            FullName = "Lucinda Riley",
                            Bio = "This is the Bio of the second author",
                            ProfilePictureURL = "https://s.lubimyczytac.pl/upload/authors/63837/785569-352x500.jpg"
                        },
                        new Author()
                        {
                            FullName = "Kate Quinn",
                            Bio = "This is the Bio of the third author",
                            ProfilePictureURL = "https://s.lubimyczytac.pl/upload/authors/103400/808444-352x500.jpg"
                        },
                        new Author()
                        {
                            FullName = "Leigh Bardugo",
                            Bio = "This is the Bio of the fourth author",
                            ProfilePictureURL = "https://s.lubimyczytac.pl/upload/authors/69633/914229-352x500.jpg"
                        },
                        new Author()
                        {
                            FullName = "B.A. Paris",
                            Bio = "This is the Bio of the fifth author",
                            ProfilePictureURL = "https://s.lubimyczytac.pl/upload/authors/139169/787832-352x500.jpg"
                        },
                         new Author()
                        {
                            FullName = "Adam Silvera",
                            Bio = "This is the Bio of the sixth author",
                            ProfilePictureURL = "https://s.lubimyczytac.pl/upload/authors/113597/871993-352x500.jpg"
                        }
                    });
                    context.SaveChanges();
                }

                //Books
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Name = "Przepaść",
                            Description = "This is the description",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/4988000/4988766/936150-352x500.jpg",
                            Price = 39.50,
                            ReleaseDate = DateTime.Now.AddDays(-10),
                            NumberOfPages =560,
                            PublishingHouseId = 1,
                            AuthorId = 1,
                            BookCategory = BookCategory.Thriller
                        },
                        new Book()
                        {
                            Name = "Siedem sióstr",
                            Description = "This is the description",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/4899000/4899052/757670-352x500.jpg",
                            Price = 39.50,
                            ReleaseDate = DateTime.Now.AddDays(-10),
                            NumberOfPages =544,
                            PublishingHouseId = 2,
                            AuthorId = 2,
                            BookCategory = BookCategory.Romance
                        },
                        new Book()
                        {
                            Name = "Kod róży",
                            Description = "This is the description",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/4988000/4988775/936163-352x500.jpg",
                            Price = 39.50,
                            ReleaseDate = DateTime.Now.AddDays(-10),
                            NumberOfPages =640,
                            PublishingHouseId = 3,
                            AuthorId = 3,
                            BookCategory = BookCategory.Historical

                        },
                        new Book()
                        {
                           Name = "Szóstka wron",
                            Description = "This is the description",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/309000/309434/534488-352x500.jpg",
                            Price = 39.50,
                            ReleaseDate = DateTime.Now.AddDays(-10),
                            NumberOfPages =496,
                            PublishingHouseId = 5,
                            AuthorId = 4,
                            BookCategory = BookCategory.Fantasy
                        },
                        new Book()
                        {
                            Name = "Terapeutka",
                            Description = "This is the description",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/4957000/4957574/899679-352x500.jpg",
                            Price = 39.50,
                            ReleaseDate = DateTime.Now.AddDays(-10),
                            NumberOfPages =100,
                            PublishingHouseId = 2,
                            AuthorId = 5,
                            BookCategory = BookCategory.Thriller
                        },
                        new Book()
                        {
                            Name = "Nasz ostatni dzień",
                            Description = "This is the description",
                            ImageURL = "https://s.lubimyczytac.pl/upload/books/4872000/4872802/786216-352x500.jpg",
                            Price = 39.50,
                            ReleaseDate = DateTime.Now.AddDays(-10),
                            NumberOfPages =100,
                            PublishingHouseId = 4,
                            AuthorId = 6,
                            BookCategory = BookCategory.Youth

                        }
                    });
                    context.SaveChanges();
                }

            }
        }


        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                ////Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@mail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@mail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
