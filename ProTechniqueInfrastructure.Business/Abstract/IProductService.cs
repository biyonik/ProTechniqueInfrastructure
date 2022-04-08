using ProTechniqueInfrastructure.Entities.Concrete;

namespace ProTechniqueInfrastructure.Business.Abstract;

public interface IProductService 
{
    Task<Product> GetByIdAsync(int ProductId);
    List<Product> GetAll();
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetListByCategory(int CategoryId);
    Task AddAsync(Product product);
    Task Delete(Product product);
    Task Update(Product product);
}