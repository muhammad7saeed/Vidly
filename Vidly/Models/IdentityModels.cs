using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //Add DRiving License to Form of Registeration
        [Required]
        [StringLength(255)]
        public string DrivingLicense { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class MyDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; } // My domain models
        public DbSet<Movie> Movies { get; set; }// My domain models
        public DbSet<MemberShipType> MemberShipTypes { get; set; }// My domain models
        public DbSet<Genre> Genres { get; set; }// My domain models

        public MyDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
    

        public static MyDBContext Create()
        {
            return new MyDBContext();
        }
    }
}