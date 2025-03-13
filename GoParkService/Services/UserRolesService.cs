using GoParkService.Entity.Entity.Identity;
using GoParkService.Repository;

namespace GoParkService.BLL.Services;
public interface IUserRolesService : ICrudService<UserRoles>
{
}

internal sealed class UserRolesService(
    IUnitOfWork unitOfWork,IUserRolesRepository userRolesRepository
    ):CrudService<UserRoles>(userRolesRepository,unitOfWork), IUserRolesService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IUserRolesRepository _userRolesRepository = userRolesRepository;
}
