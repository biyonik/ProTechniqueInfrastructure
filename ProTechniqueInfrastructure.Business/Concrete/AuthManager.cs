using ProTechniqueInfrastructure.Core.Entities.Concrete;
using ProTechniqueInfrastructure.Core.Utilities.Security.Hashing;
using ProTechniqueInfrastructure.Core.Utilities.Security.JWT;
using ProTechniqueInfrastructure.Entities.DTOs.UserDtos;

namespace ProTechniqueInfrastructure.Business.Concrete;

public class AuthManager: IAuthService
{
    private readonly IUserService _userService;
    private readonly ITokenHelper _tokenHelper;
    
    public AuthManager(IUserService userService, ITokenHelper tokenHelper)
    {
        _userService = userService;
        _tokenHelper = tokenHelper;
    }
    
    public async Task<IDataResult<User>> RegisterAsync(UserForRegisterDto userForRegisterDto, string password)
    {
        byte[] passwordHash;
        byte[] passwordSalt;
        HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        User user = new User
        {
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            LastName = userForRegisterDto.LastName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Status = true
        };
        await _userService.AddAsync(user);
        return new SuccessDataResult<User>(user, Messages.RegisterIsSuccessfully);
    }

    public async Task<IDataResult<User>> LoginAsync(UserForLoginDto userForLoginDto)
    {
        var userToCheck = await _userService.GetByMailAsync(userForLoginDto.Email);
        if (userToCheck.Data == null)
        {
            return new ErrorDataResult<User>(Messages.UserNotFound);
        }

        if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash,
                userToCheck.Data.PasswordSalt))
        {
            return new ErrorDataResult<User>(Messages.PasswordError);
        }

        return new SuccessDataResult<User>(userToCheck.Data, Messages.LoginIsSuccessfully);
    }

    public async Task<IResult> UserExistsAsync(string email)
    {
        var userExists = await _userService.GetByMailAsync(email);
        if (userExists.Data != null)
        {
            return new ErrorResult(Messages.UserAlreadyExists);
        }

        return new SuccessResult();
    }

    public async Task<IDataResult<AccessToken>> CreateAccessTokenAsync(User user)
    {
        var claims = await _userService.GetClaimsAsync(user);
        var accessToken = _tokenHelper.CreateToken(user, claims.Data.ToList());
        return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
    }
}