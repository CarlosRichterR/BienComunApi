using BienComun.Core.DTOs;

namespace BienComun.Core.Repository
{
    public interface IUserRepository
    {
        Task<bool> ValidateUserAsync(LoginRequestDto loginRequest);
    }
}
