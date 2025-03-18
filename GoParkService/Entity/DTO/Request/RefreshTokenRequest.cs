namespace GoParkService.Entity.DTO.Request;

public class RefreshTokenRequest
{
    public string RefreshToken { get; set; }

    public DateTime RefreshTokenExpiryTime { get; set; }
}
