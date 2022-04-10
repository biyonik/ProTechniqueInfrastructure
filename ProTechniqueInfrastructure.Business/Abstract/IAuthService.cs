using ProTechniqueInfrastructure.Core.Entities.Concrete;
using ProTechniqueInfrastructure.Core.Utilities.Security.JWT;
using ProTechniqueInfrastructure.Entities.DTOs.UserDtos;

namespace ProTechniqueInfrastructure.Business.Abstract;

public interface IAuthService
{
    Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password);
    Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto);
    Task<IResult> UserExistsAsync(string email);
    Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user);
}