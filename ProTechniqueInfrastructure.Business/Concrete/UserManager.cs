using ProTechniqueInfrastructure.Core.Entities.Concrete;

namespace ProTechniqueInfrastructure.Business.Concrete;

public class UserManager: IUserService
{
    private readonly IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
        _userDal = userDal;
    }
    
    public async Task<IDataResult<ICollection<OperationClaim>>> GetClaimsAsync(User user)
    {
        var claims = await _userDal.GetClaims(user);
        return new SuccessDataResult<ICollection<OperationClaim>>(claims);
    }

    public async Task<IResult> AddAsync(User user)
    {
        await _userDal.AddAsync(user);
        return new SuccessResult(Messages.UserAdded);
    }

    public async Task<IDataResult<User>> GetByMailAsync(string email)
    {
        var user = await _userDal.GetAsync(x => x.Email == email);
        return user != null
            ? new SuccessDataResult<User>(user)
            : new ErrorDataResult<User>(Messages.UserNotFound);
    }
}