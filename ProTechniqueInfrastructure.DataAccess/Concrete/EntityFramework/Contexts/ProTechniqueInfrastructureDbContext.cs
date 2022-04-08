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
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
    }

    public DbSet<Product> Products {get; set;}
}