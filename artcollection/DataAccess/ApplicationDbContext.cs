using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using static ArtCollection.Models.ApplicationUser;

namespace ArtCollection.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(store);

            var mainUser = new ApplicationUser
            {
                UserName ="wirendavid@gmail.com",
                Email ="wirendavid@gmail.com",
                FirstName ="David",
                LastName ="Wiren",
                Description ="Studerar Systemvetenskapliga programmet vid Örebro Universitet. Här kommer lite egna arbeten att bli publicerade.",
                BirthDate ="1991-09-23",
                Age=26
            };

            userManager.CreateAsync(mainUser, "P455-w0rd").Wait();


            //SeedCategories(context);
            context.SaveChanges();

            var caties = new List<Category>
            {
                new Category{CategoryName="Summer"},
                new Category{CategoryName="Winter"},
                new Category{CategoryName="Autumn"}
            };
            caties.ForEach(x => context.Categories.Add(x));
            context.SaveChanges();
            base.Seed(context);
        }
        //private static void SeedCategories(ApplicationDbContext context)
        //{
        //    var Summer = new Category { CategoryName = "Summer" };
        //    var Winter = new Category { CategoryName = "Winter" };
        //    var Autumn = new Category { CategoryName = "Autumn" };

        //    context.Categories.AddRange(new[] {
        //        Summer,
        //        Winter,
        //        Autumn
        //    });
        //}
    }
}