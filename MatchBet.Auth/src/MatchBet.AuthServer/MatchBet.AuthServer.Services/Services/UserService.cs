using AuthServer.Core.DTOs;
using AuthServer.Core.Entities;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Identity;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service.Services
{
    public class UserService : IUserService
    { 

        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<AppUserDTO>> CreateUserAsync(CreateUserDTO createUserDto)
        {
            var user = new AppUser { Email = createUserDto.Email, UserName = createUserDto.UserName, Credit = 3, Score = 0 };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<AppUserDTO>.Fail(400,new ErrorDto(errors, true));
            }
            return Response<AppUserDTO>.Success(ObjectMapper.Mapper.Map<AppUserDTO>(user), 200);
        }

        public async Task<Response<AppUserDTO>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Response<AppUserDTO>.Fail("UserName not found", 404, true);
            }

            return Response<AppUserDTO>.Success(ObjectMapper.Mapper.Map<AppUserDTO>(user), 200);
        }
    }
}
