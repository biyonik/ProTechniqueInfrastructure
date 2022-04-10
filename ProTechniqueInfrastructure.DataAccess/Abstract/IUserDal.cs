using ProTechniqueInfrastructure.Core.Entities.Concrete;

namespace ProTechniqueInfrastructure.DataAccess.Abstract;

public interface IUserDal: IEntityRepository<User>
{
    Task<List<OperationClaim>> GetClaims(User user);
}