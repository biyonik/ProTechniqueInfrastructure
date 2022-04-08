using ProTechniqueInfrastructure.Business.Abstract;
using ProTechniqueInfrastructure.DataAccess.Abstract;
using ProTechniqueInfrastructure.Entities.Concrete;

namespace ProTechniqueInfrastructure.Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    public async Task AddAsync(Product product)
    {
        await _productDal.AddAsync(product);
    }

    public async Task Delete(Product product)
    {
        await _productDal.DeleteAsync(product);
    }

    public List<Product> GetAll()
    {
        return _productDal.GetAll().ToList();
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return (List<Product>) await _productDal.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int ProductId)
    {
        return await _productDal.GetAsync(p => p.ProductId == ProductId); 
    }

    public async Task<List<Product>> GetListByCategory(int CategoryId)
    {
        return (List<Product>) await _productDal.GetAllAsync(p => p.CategoryId == CategoryId);
    }

    public async Task Update(Product product)
    {
        await _productDal.UpdateAsync(product);
    }
}