using ProTechniqueInfrastructure.Core.DataAccess.EntityFramework;
using ProTechniqueInfrastructure.Core.Entities.Concrete;
using ProTechniqueInfrastructure.DataAccess.Concrete.EntityFramework.Contexts;

namespace ProTechniqueInfrastructure.DataAccess.Concrete.EntityFramework.Repositories;

public class EfUserDal : EfEntityRepositoryBase<User, ProTechniqueInfrastructureDbContext>, IUserDal
{
    public async Task<List<OperationClaim>> GetClaims(User user)
    {
        await using var context = new ProTechniqueInfrastructureDbContext();
        var result = from operationClaim in context.OperationClaims
            join userOperationClaim in context.UserOperationClaims 
                on operationClaim.Id equals userOperationClaim.OperationClaimId
            where userOperationClaim.UserId == user.Id
            select new OperationClaim
            {
                Id = operationClaim.Id,
                Name = operationClaim.Name
            };
        return await result.ToListAsync();
    }
}