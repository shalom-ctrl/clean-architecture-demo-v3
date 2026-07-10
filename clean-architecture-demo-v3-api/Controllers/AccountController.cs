using Demo.Application.DTOs;
using Demo.Application.Features.Product.Commands;
using Demo.Application.Features.Product.Queries;
using Demo.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_demo_v3_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Auth")]
        public async Task<IActionResult> Authentication(AuthenticationRequest authentication, CancellationToken cancellationToken)
        {
           var result =  await _accountService.Authenticate(authentication);
            return Ok(result);
        }

        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterRequest register, CancellationToken cancellationToken)
        {
           var result =  await _accountService.RegisterUser(register);
           return Ok(result);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token, CancellationToken cancellationToken)
        {
            var result = await _accountService.ConfirmEmail(userId, token);
            return Ok(result);
        }

        [HttpGet("resend-confirm-email")]
        public async Task<IActionResult> ResendConfirmEmail([FromQuery] string email, CancellationToken cancellationToken)
        {
            var result = await _accountService.ResendConfirmationEmailAsync(email);
            return Ok(result);
        }
    }
}
