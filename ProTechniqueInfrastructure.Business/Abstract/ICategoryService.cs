namespace ProTechniqueInfrastructure.Business.Abstract;

public interface ICategoryService
{
    Task<IDataResult<Category>> GetByIdAsync(int CategoryId);
    Task<IDataResult<ICollection<Category>>> GetAllAsync();
    Task<IResult> AddAsync(Category category);
    Task<IResult> Delete(Category category);
    Task<IResult> Update(Category category);
}