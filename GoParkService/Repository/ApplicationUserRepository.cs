using GoParkService.Entity.Entity.Identity;

namespace GoParkService.Repository;
public interface IApplicationUserRepository : IRepository<ApplicationUser>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public Task<ApplicationUser> GetById(Guid id);
}


public sealed class ApplicationUserRepository(
    IUnitOfWork unitOfWork,
    ILogger<ApplicationUserRepository> logger
    ) : Repository<ApplicationUser>(unitOfWork, logger), IApplicationUserRepository
{
    private readonly IUnitOfWork _unitOfWork =unitOfWork;
    private readonly ILogger<ApplicationUserRepository> _logger = logger;
    public async Task<ApplicationUser> GetById(Guid id)
    {
        var user = new ApplicationUser();
        try
        {
            _logger.LogError("Getting ApplicationUser by Id");
            user = (from use in _unitOfWork.Context.Users
                         where
                         use.Id.Equals(id)
                         //&& use.IsDeleted.Equals(false)

                         select new ApplicationUser
                         {
                             FirstName = use.FirstName,
                             LastName = use.LastName,
                             UsernameChangeLimit = use.UsernameChangeLimit,
                             Id = use.Id,
                             SecurityStamp = use.SecurityStamp,
                             UserName = use.UserName,
                             NormalizedUserName = use.NormalizedUserName,
                             Email = use.Email,
                             NormalizedEmail = use.NormalizedEmail,
                             EmailConfirmed = use.EmailConfirmed,
                             PasswordHash = use.PasswordHash,
                             ConcurrencyStamp = use.ConcurrencyStamp,
                             PhoneNumber = use.PhoneNumber,
                             PhoneNumberConfirmed = use.PhoneNumberConfirmed,
                             TwoFactorEnabled = use.TwoFactorEnabled,
                             LockoutEnd = use.LockoutEnd,
                             LockoutEnabled = use.LockoutEnabled,
                             AccessFailedCount = use.AccessFailedCount,
                         }).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
            throw new Exception(ex.Message, ex.InnerException);
        }
        _logger.LogError("Returning ApplicationUser :" + user);
        return await Task.FromResult(user);
    }
}
