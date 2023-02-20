using AuthServer.Core.DTOs;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Services
{
    public interface IUserService
    {
        Task<Response<AppUserDTO>> CreateUserAsync(CreateUserDTO createUserDto);

        Task<Response<AppUserDTO>> GetUserByNameAsync(string userName);
    }
}
