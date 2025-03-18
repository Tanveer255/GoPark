using GoParkService.Entity.DTO.Request;
using GoParkService.Entity.DTO;
using GoParkService.Entity.Entity.Identity;
using GoParkService.Repository;
using Microsoft.EntityFrameworkCore;
using GoParkService.Services;

namespace GoParkService.BLL.Services;
public interface IApplicationUserService : ICrudService<ApplicationUser>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    public Task<ApplicationUser> GetById(Guid Id);
    public bool ExistUser(string email);
    public Task<ApplicationUser> GetUserByEmail(string email);
    public Task<ResultDTO<RefreshTokenRequest>> RefreshUserTokenAsync(GenerateTokenRequest request);
}
public sealed class ApplicationUserService(IApplicationUserRepository applicationUserRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor,
         IJwtAuthenticationService jwtAuthentication
    ) : CrudService<ApplicationUser>(applicationUserRepository,unitOfWork), IApplicationUserService
{
    private readonly IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
    private readonly IUnitOfWork _unitOfWork =unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
    private readonly IJwtAuthenticationService _jwtAuthentication = jwtAuthentication;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ApplicationUser> GetById(Guid id)
    {
        var result = await _applicationUserRepository.GetById(id);
        return result;
    }
    public bool ExistUser(string email)
    {
        var exist =  _unitOfWork.Context.Users.Where(e=>e.Email.Equals(email)).FirstOrDefault();
        if (exist != null)
        {
            return true;
        }

        return false;
    }
    public async Task<ApplicationUser> GetUserByEmail(string email)
    {
        var user = await _unitOfWork.Context.Users.Where(e=>e.Email.Equals(email)).FirstOrDefaultAsync();
        if (user== null)
            return null;
        return user;
    }
    public async Task<ResultDTO<RefreshTokenRequest>> RefreshUserTokenAsync(GenerateTokenRequest request)
    {

        var result = await _jwtAuthentication.RefreshTokenAsync(request);
        var user = new ApplicationUser
        {
            RefreshToken = result.RefreshToken,
            RefreshTokenExpiryTime = result.RefreshTokenExpiryTime
        };
        await _applicationUserRepository.Update(user);
        _unitOfWork.Commit();
        var refereshToken = new RefreshTokenRequest
        {
            RefreshToken = result.RefreshToken,
            RefreshTokenExpiryTime = result.RefreshTokenExpiryTime
        };
        return ResultDTO<RefreshTokenRequest>.Success(refereshToken, "Token is refreshed successfully.");
    }
}
