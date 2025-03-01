﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Classes.Dtos.User;
using SocialMedia.Classes.Interfaces;
using SocialMedia.Classes.Mappers;
using SocialMedia.Classes.Models;

namespace SocialMedia.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(UserManager<UserModel> userManager, IAuthService authService) : ControllerBase
    {
        [HttpGet("user")]
        public IActionResult GetUser()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                var userClaims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();
                return Ok(userClaims);
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerDto)
        {
            var user = registerDto.ToUserModel();

            var createdUser = await userManager.CreateAsync(user, registerDto.Password);

            if (!createdUser.Succeeded)
            {
                return StatusCode(500, createdUser.Errors);
            }

            var createdRole = await userManager.AddToRoleAsync(user, "user");

            if (!createdRole.Succeeded)
            {
                return StatusCode(500, createdRole.Errors);
            }

            // var addToRole = await AssignRole(user.Id, "User");
            var token = await authService.GenerateAccessToken(user);
            var response = user.ToAuthResponseDto(token);

            return CreatedAtAction(nameof(Register), new { user.Id }, user.ToGetUserResponseDto());
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email) && string.IsNullOrEmpty(loginDto.UserName))
            {
                return BadRequest("Please provide an email or username!");
            }

            var response = await authService.Login(loginDto);

            if (response is null)
            {
                return Unauthorized("Username or password incorrects!");
            }

            return Ok(response);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await authService.Logout();
            return NoContent();
        }
    }
}
