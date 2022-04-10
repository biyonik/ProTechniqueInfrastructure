namespace ProTechniqueInfrastructure.Business.Concrete;

public class CategoryManager: ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }
    
    public async Task<IDataResult<Category>> GetByIdAsync(int CategoryId)
    {
        var category = await _categoryDal.GetAsync(c => c.CategoryId == CategoryId);
        return new SuccessDataResult<Category>(category);
    }

    public async Task<IDataResult<ICollection<Category>>> GetAllAsync()
    {
        var categories = (await _categoryDal.GetAllAsync()).ToList();
        return new SuccessDataResult<ICollection<Category>>(categories);
    }

    public async Task<IResult> AddAsync(Category category)
    {
        await _categoryDal.AddAsync(category);
        return new SuccessResult(Messages.CategoryAdded);
    }

    public async Task<IResult> Delete(Category category)
    {
        await _categoryDal.DeleteAsync(category);
        return new SuccessResult(Messages.CategoryDeleted);
    }

    public async Task<IResult> Update(Category category)
    {
        await _categoryDal.UpdateAsync(category);
        return new SuccessResult(Messages.CategoryUpdated);
    }
}