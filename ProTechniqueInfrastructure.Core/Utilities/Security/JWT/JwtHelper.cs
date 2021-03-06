using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProTechniqueInfrastructure.Core.Entities.Concrete;
using ProTechniqueInfrastructure.Core.Extensions;
using ProTechniqueInfrastructure.Core.Utilities.Security.Encryption;

namespace ProTechniqueInfrastructure.Core.Utilities.Security.JWT;

public class JwtHelper: ITokenHelper
{
    private readonly IConfiguration Configuration;
    private readonly TokenOptions _tokenOptions;
    private readonly DateTime _accessTokenExpiration;

    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
    }
    public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
    {
        var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        string token = jwtSecurityTokenHandler.WriteToken(jwt);
        AccessToken accessToken = new AccessToken
        {
            Token = token,
            Expiration = _accessTokenExpiration
        };
        return accessToken;
    }

    public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
    {
        var jwt = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Audience,
            expires: _accessTokenExpiration,
            notBefore: DateTime.Now,
            claims: SetClaims(user, operationClaims),
            signingCredentials: signingCredentials
        );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
    {
        var claims = new List<Claim>();
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddName($"{user.FirstName} {user.LastName}");
        claims.AddEmail(user.Email);
        claims.AddRoles(operationClaims.Select(oc => oc.Name).ToArray());
        return claims;
    }
}