using GoParkService.Entity.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoParkService.Repository;
public interface IManageUserRolesRepository : IRepository<ManageUserRoles>
{
}

internal sealed class ManageUserRolesRepository(
    IUnitOfWork unitOfWork,
    ILogger<ManageUserRolesRepository> logger
    ) : Repository<ManageUserRoles>(unitOfWork, logger), IManageUserRolesRepository
{
   private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<ManageUserRolesRepository> _logger = logger;
}
