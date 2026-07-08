using Demo.Application.DTOs;
using Demo.Application.Enums;
using Demo.Application.Exceptions;
using Demo.Application.Interfaces;
using Demo.Application.Wrappers;
using Demo.Persistence.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Persistence.SharedServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<Guid>> RegisterUser(RegisterRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                throw new ApiException("User with this email already exists.");
            }

            var userModel = new ApplicationUser();

            userModel.FirstName = request.FirstName;
            userModel.LastName = request.LastName;
            userModel.UserName = request.Username;
            userModel.Email = request.Email;
            userModel.Gender = request.Gender;
            userModel.EmailConfirmed = true;
            userModel.PhoneNumberConfirmed = true;

            var result = await _userManager.CreateAsync(userModel, request.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(userModel, Roles.Basic.ToString());
                return new ApiResponse<Guid>(userModel.Id, "User registered successfully.");
            }
            else
            {
                var errorMessages = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new ApiException(errorMessages);
            }
        }
    }
}
