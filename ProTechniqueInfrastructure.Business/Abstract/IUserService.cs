using ProTechniqueInfrastructure.Core.Entities.Concrete;

namespace ProTechniqueInfrastructure.Business.Abstract;

public interface IUserService
{
    Task<IDataResult<ICollection<OperationClaim>>> GetClaimsAsync(User user);
    Task<IResult> AddAsync(User user);
    Task<IDataResult<User>> GetByMailAsync(string email);
}