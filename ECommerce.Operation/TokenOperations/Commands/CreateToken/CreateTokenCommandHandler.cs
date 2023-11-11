using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ECommerce.Base;
using ECommerce.Base.JwtToken;
using ECommerce.Base.Response;
using ECommerce.Data.Context;
using ECommerce.Data.Domain;
using ECommerce.Operation.TokenOperations.Cqrs;
using ECommerce.Schema;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace ECommerce.Operation.TokenOperations.Commands.CreateToken;

public class TokenCommandHandler :
    IRequestHandler<CreateTokenCommand, ApiResponse<TokenResponse>>

{
    private readonly ECommerceDbContext dbContext;
    private readonly JwtConfig jwtConfig;

    public TokenCommandHandler(ECommerceDbContext dbContext, IOptionsMonitor<JwtConfig> jwtConfig)
    {
        this.dbContext = dbContext;
        this.jwtConfig = jwtConfig.CurrentValue;
    }


    public async Task<ApiResponse<TokenResponse>> Handle(CreateTokenCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await dbContext.Set<User>().Include(x => x.Role).FirstOrDefaultAsync(x => x.UserName == request.Model.UserName, cancellationToken);
        if (entity == null)
        {
            return new ApiResponse<TokenResponse>("Invalid user informations");
        }
        string hashedPassword = Md5.Create(request.Model.Password);

        if (entity.Password != hashedPassword)
        {
            entity.LastActivityDate = DateTime.UtcNow;
            entity.PasswordRetryCount++;
            await dbContext.SaveChangesAsync(cancellationToken);

            return new ApiResponse<TokenResponse>("Invalid user informations!");
        }

        if (!entity.IsActive)
        {
            return new ApiResponse<TokenResponse>("Invalid user!");
        }

        string token = Token(entity);
        TokenResponse tokenResponse = new()
        {
            Token = token,
            ExpireDate = DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            UserName = entity.UserName,
            Email = entity.Email
        };

        return new ApiResponse<TokenResponse>(tokenResponse);

    }

    private string Token(User user)
    {
        Claim[] claims = GetClaims(user);
        var secret = Encoding.ASCII.GetBytes(jwtConfig.Secret);

        var jwtToken = new JwtSecurityToken(
            jwtConfig.Issuer,
            jwtConfig.Audience,
            claims,
            expires: DateTime.Now.AddMinutes(jwtConfig.AccessTokenExpiration),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
        );

        string accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return accessToken;
    }


    private Claim[] GetClaims(User user)
    {
        var claims = new[]
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("UserName", user.UserName.ToString()),
            new Claim("Role", user.Role.Name),
            new Claim("Email", user.Email),
            //new Claim(ClaimTypes.Role, user.Role.Name),
            new Claim("FullName", $"{user.Name} {user.LastName}")
        };

        return claims;
    }
}