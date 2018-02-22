using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ArtCollection.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string BirthDate { get; set; }
        public int Age { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public byte[] Picture { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Category> Categories { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class Image
    {
        public Image()
        {
            ImageList = new List<string>();
        }
        public int ImageId { get; set; }
        public byte[] Picture { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public List<string> ImageList { get; set; }
        public virtual List<Post> Posts { get; set; }
    }
    public class Post
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public virtual Image Image { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Picture { get; set; }
        public virtual ApplicationUser catCreatedBy { get; set; }
    }

}