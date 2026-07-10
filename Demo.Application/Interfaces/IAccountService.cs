using Demo.Application.DTOs;
using Demo.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResponse<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
        Task<ApiResponse<Guid>> RegisterUser(RegisterRequest request);

        Task<ApiResponse<bool>> ConfirmEmail(string userId, string token);
        Task<ApiResponse<bool>> ResendConfirmationEmailAsync(string email);
    }
}
