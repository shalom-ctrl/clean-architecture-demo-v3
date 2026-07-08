using Demo.Application.DTOs;
using Demo.Application.Features.Product.Commands;
using Demo.Application.Features.Product.Queries;
using Demo.Application.Interfaces;
using MediatR;
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


        [HttpPost("RegisterUser")]
        public async Task<IActionResult> RegisterUser(RegisterRequest register, CancellationToken cancellationToken)
        {
           var result =  await _accountService.RegisterUser(register);
           return Ok(result);
        }

    }
}
