using Domain.Models;

namespace UseCases.Ports.Output;

public interface IAuthService
{
    Task<string> GetUserIdAsync();
    string GetUserEmail();
    Task<DbUser> GetUserByEmailAsync(string email);
    bool IsUserAdmin();
}
