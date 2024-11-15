using BienComun.Core.DTOs;

namespace BienComun.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ValidateUserAsync(LoginRequestDto loginRequest);
    }
}
