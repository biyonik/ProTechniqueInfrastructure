namespace ProTechniqueInfrastructure.DataAccess.Concrete.EntityFramework.Contexts;

public class ProTechniqueInfrastructureDbContext : DbContext
{ 
    private readonly IConfiguration _configuration;
    public ProTechniqueInfrastructureDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ProTechniqueInfrastructureDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Product> Products {get; set;}
}