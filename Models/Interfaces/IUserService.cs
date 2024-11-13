using BienComun.Core.DTOs;

namespace Services;

public interface IUserService
{
    Task<bool> LoginAsync(LoginRequestDto loginRequest);
}
