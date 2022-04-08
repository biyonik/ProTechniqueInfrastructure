namespace ProTechniqueInfrastructure.Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    
    public async Task<IResult> AddAsync(Product product)
    {
        await _productDal.AddAsync(product);
        return new SuccessResult(message: Messages.ProductAdded);
    }

    public async Task<IResult> Delete(Product product)
    {
        await _productDal.DeleteAsync(product);
        return new SuccessResult(message: Messages.ProductDeleted);
    }

    public IDataResult<List<Product>> GetAll()
    {
        var data = _productDal.GetAll().ToList();
        return new SuccessDataResult<List<Product>>(data);
    }

    public async Task<IDataResult<List<Product>>> GetAllAsync()
    {
        var data = (List<Product>) await _productDal.GetAllAsync();
        return new SuccessDataResult<List<Product>>(data);
    }

    public async Task<IDataResult<Product>> GetByIdAsync(int ProductId)
    {
        var data = await _productDal.GetAsync(p => p.ProductId == ProductId); 
        return new SuccessDataResult<Product>(data);
    }

    public async Task<IDataResult<List<Product>>> GetListByCategory(int CategoryId)
    {
        var data = (List<Product>) await _productDal.GetAllAsync(p => p.CategoryId == CategoryId);
        return new SuccessDataResult<List<Product>>(data);
    }

    public async Task<IResult> Update(Product product)
    {
        await _productDal.UpdateAsync(product);
        return new SuccessResult(message: Messages.ProductUpdated);
    }
}