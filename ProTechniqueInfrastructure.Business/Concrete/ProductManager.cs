using ProTechniqueInfrastructure.Business.BusinessAspects.Autofac;
using ProTechniqueInfrastructure.Business.ValidationRules.FluentValidation;
using ProTechniqueInfrastructure.Core.Aspects.Autofac.Caching;
using ProTechniqueInfrastructure.Core.Aspects.Autofac.Logging;
using ProTechniqueInfrastructure.Core.Aspects.Autofac.Performance;
using ProTechniqueInfrastructure.Core.Aspects.Autofac.Transaction;
using ProTechniqueInfrastructure.Core.Aspects.Autofac.Validation;
using ProTechniqueInfrastructure.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace ProTechniqueInfrastructure.Business.Concrete;

public class ProductManager : IProductService
{
    private readonly IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }
    
    [SecuredOperation("Product.Add,Admin")]
    [ValidationAspect(typeof(ProductValidator), Priority = 1)]
    [CacheRemoveAspect("IProductService.Get")]
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
    
    [PerformanceAspect(5)]
    public IDataResult<List<Product>> GetAll()
    {
        var data = _productDal.GetAll().ToList();
        return new SuccessDataResult<List<Product>>(data);
    }

    [PerformanceAspect(5)]
    [LogAspect(typeof(JsonFileLogger))]
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

    [SecuredOperation("Product.List,Admin")]
    [CacheAspect(10)]
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

    [TransactionScopeAspect]
    public async Task<IResult> TransactionalOperation(Product product)
    {
        await _productDal.UpdateAsync(product);
        await _productDal.AddAsync(product);
        return new SuccessResult(message: Messages.ProductUpdated);
    }
}