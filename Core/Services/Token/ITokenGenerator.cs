
namespace Core.Services.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(string idUser, string role);
    }
}
