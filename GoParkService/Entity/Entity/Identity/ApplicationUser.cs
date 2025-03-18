using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GoParkService.Entity.Entity.Identity;

public class ApplicationUser : IdentityUser<Guid>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public override Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int UsernameChangeLimit { get; set; } = 10;
    public byte[] ProfilePicture { get; set; } = new byte[0];
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiryTime { get; set; }
    public string TenantId { get; set; } = string.Empty;

}

