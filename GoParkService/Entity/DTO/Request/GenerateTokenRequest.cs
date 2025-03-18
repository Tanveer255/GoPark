namespace GoParkService.Entity.DTO.Request;

public class GenerateTokenRequest
{
    public Guid UserId { get; set; }
    public string Email { get; set; } = string.Empty;
}
