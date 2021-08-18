using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Toy.Entities;
using Toy.Entities.Interfaces;
using Toy.Services.Dto.Input;
using Toy.Services.Services;
using Toy.Services.Services.Tokens;

namespace ToyProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;
        private readonly IPasswordHasher passwordHasher;
        private readonly AccessTokenGenerator tokenGenerator;
        private readonly RefreshTokenGenerator refreshTokenGenerator;
        private readonly RefreshTokenValidator refreshTokenValidator;
        private readonly IRefreshTokenRepository refreshTokenRepository;
        public UserController(IUserServices userServices, IPasswordHasher passwordHasher, AccessTokenGenerator tokenGenerator, RefreshTokenGenerator refreshTokenGenerator, RefreshTokenValidator refreshTokenValidator, IRefreshTokenRepository refreshTokenRepository)
        {
            this.userServices = userServices;
            this.passwordHasher = passwordHasher;
            this.tokenGenerator = tokenGenerator;
            this.refreshTokenGenerator = refreshTokenGenerator;
            this.refreshTokenValidator = refreshTokenValidator;
            this.refreshTokenRepository = refreshTokenRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserInsertDto userRegister)
        {
            if (!ModelState.IsValid)
            {
                BadRequestStateModel();
            }
            if (userRegister.Password != userRegister.ConfirmPassword)
            {
                return BadRequest(new ErrorResponse("Password does not match"));
            }
            User existingUserByEmail = await userServices.GetByEmail(userRegister.Email);
            if (existingUserByEmail != null)
            {
                return Conflict(new ErrorResponse("Email already exists"));
            }
            User existingUserByUsername = await userServices.GetByUsername(userRegister.Username);
            if (existingUserByUsername != null)
            {
                return Conflict(new ErrorResponse("Username already exists"));
            }
            if (String.IsNullOrEmpty(userRegister.Role))
            {
                return BadRequest(new ErrorResponse("Role cannot be empty"));
            }

            var output = await userServices.Insert(userRegister);
            return Ok(output);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestStateModel();
            }
            User user = await userServices.GetByUsername(userLogin.Username);
            if (user == null)
            {
                return Unauthorized(new ErrorResponse("Username does not exist"));
            }
            var isCorrectPassword = passwordHasher.VerifyPassword(userLogin.Password, user.PasswordHash);
            if (!isCorrectPassword)
            {
                return Unauthorized(new ErrorResponse("Password is not correct"));
            }

            string accessToken = tokenGenerator.GenerateToken(user);
            string refreshToken = refreshTokenGenerator.GenerateToken();

            RefreshToken refreshTokenDto = new RefreshToken()
            {
                UserId = user.Id,
                Token = refreshToken
            };
            await refreshTokenRepository.Create(refreshTokenDto);

            return Ok(new AuthenticatedUserResponse() {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });

        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest refreshRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestStateModel();
            }
            bool isValidRefreshToken = refreshTokenValidator.ValidateRefreshToken(refreshRequest.RefreshToken);
            if (!isValidRefreshToken)
            {
                return BadRequest(new ErrorResponse("Refresh token is not valid"));
            }
            RefreshToken refreshTokenDto = await refreshTokenRepository.GetByToken(refreshRequest.RefreshToken);
            if (refreshTokenDto == null)
            {
                return NotFound(new ErrorResponse("Refresh token is not valid"));

            }
            User user = await userServices.Get(refreshTokenDto.UserId);
            if (user == null)
            {
                return NotFound(new ErrorResponse("User not found"));
            }
            string accessToken = tokenGenerator.GenerateToken(user);
            string refreshToken = refreshTokenGenerator.GenerateToken();

            RefreshToken refreshTokenToInsert = new RefreshToken()
            {
                UserId = user.Id,
                Token = refreshToken
            };
            await refreshTokenRepository.Create(refreshTokenToInsert);
            await refreshTokenRepository.DeleteToken(refreshTokenDto);

            return Ok(new AuthenticatedUserResponse()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });

        }

        [Authorize]
        [HttpDelete("logout")]
        public async Task<IActionResult> Logout()
        {
            int id = int.Parse(HttpContext.User.FindFirstValue("id"));
            await refreshTokenRepository.DeleteAll(id);
            return NoContent();
        }

        private IActionResult BadRequestStateModel()
        {
            IEnumerable<string> errorMessages = ModelState.Values.SelectMany(x => x.Errors.Select(t => t.ErrorMessage));
            return BadRequest(new ErrorResponse(errorMessages));
        }

        [Authorize]
        [HttpPut("edit")]
        public async Task<IActionResult> Update(User user)
        {
            await userServices.Update(user);
            return Ok();
        }

    }
}
