using ProTechniqueInfrastructure.Core.Entities.Concrete;

namespace ProTechniqueInfrastructure.Core.Utilities.Security.JWT;

public interface ITokenHelper
{
    AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
}