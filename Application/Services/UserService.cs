using BienComun.Core.DTOs;
using BienComun.Core.Repository;
using BIenComun.Infrastructure.Repositories;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIenComun.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> LoginAsync(LoginRequestDto loginRequest)
    {
        // Aquí puedes aplicar lógica adicional antes de validar al usuario
        return await _userRepository.ValidateUserAsync(loginRequest);
       
    }
}
