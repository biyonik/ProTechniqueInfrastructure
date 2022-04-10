using ProTechniqueInfrastructure.Core.Entities.Concrete;

namespace ProTechniqueInfrastructure.DataAccess.Concrete.EntityFramework.Contexts;

public class ProTechniqueInfrastructureDbContext : DbContext
{ 
    // private readonly IConfiguration _configuration;
    // public ProTechniqueInfrastructureDbContext(IConfiguration configuration)
    // {
    //     _configuration = configuration;
    // }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-NOOAEV8\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;");
    }

    public DbSet<Product> Products {get; set;}
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}