namespace WebApp.Models
{
    public interface ITokenService
    {
        string GenerateJwtToken(string username, string role);
    }
}
