using BienComun.Core.DTOs;
using BienComun.Infrastructure.Repositories;
using BIenComun.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIenComun.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ValidateUserAsync(LoginRequestDto loginRequest)
    {
        // Busca un usuario que coincida con el nombre de usuario y la contraseña
        var user = await _context.Users
            .FirstOrDefaultAsync(u => 
            u.Username == loginRequest.Username && u.Password == loginRequest.Password);

        // Retorna true si el usuario existe, de lo contrario, false
        return user != null;
    }

}
