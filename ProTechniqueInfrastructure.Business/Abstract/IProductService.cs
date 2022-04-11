namespace ProTechniqueInfrastructure.Business.Abstract;

public interface IProductService 
{
    Task<IDataResult<Product>> GetByIdAsync(int ProductId);
    IDataResult<List<Product>> GetAll();
    Task<IDataResult<List<Product>>> GetAllAsync();
    Task<IDataResult<List<Product>>> GetListByCategory(int CategoryId);
    Task<IResult> AddAsync(Product product);
    Task<IResult> Delete(Product product);
    Task<IResult> Update(Product product);

    Task<IResult> TransactionalOperation(Product product);
}