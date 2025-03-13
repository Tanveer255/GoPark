using GoParkService.Entity.Entity.Identity;
using GoParkService.Repository;
using Microsoft.EntityFrameworkCore;

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
}
public sealed class ApplicationUserService(IApplicationUserRepository applicationUserRepository,
         IUnitOfWork unitOfWork,
         IHttpContextAccessor httpContextAccessor
    ) : CrudService<ApplicationUser>(applicationUserRepository,unitOfWork), IApplicationUserService
{
    private readonly IApplicationUserRepository _applicationUserRepository = applicationUserRepository;
    private readonly IUnitOfWork _unitOfWork =unitOfWork;
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext;
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
}
