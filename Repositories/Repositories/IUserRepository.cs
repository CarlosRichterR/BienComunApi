using BienComun.Core.DTOs;

namespace BIenComun.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ValidateUserAsync(LoginRequestDto loginRequest);
    }
}
