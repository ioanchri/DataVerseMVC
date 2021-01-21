using Dataverse_Web_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Dataverse_Web_Project.Data
{
    public class DataverseDBContext:DbContext
    {
        public DbSet<Customer> Customers { get; set; }



        public readonly static string connectionString =
            "Server =localhost;" +
            "Database =DataverseDB;" +
            "User Id =sa;" +
            "Password =1234qwer!;";

        protected override void OnConfiguring
           (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }
    }


}
