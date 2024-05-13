using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Authentication.DTOs;
using WinglyShop.Application.Authentication.Login;
using WinglyShop.Application.Authentication.Register;
using WinglyShop.Domain.Common.DTOs.Users;
using WinglyShop.Domain.Entities.Users;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class AuthController : ApiController
{
	private readonly ITokenService _tokenService;

	public AuthController(
		IDatabaseContext databaseContext, 
		IDbConnection dbConnection, 
		IDispatcher dispatcher, 
		ITokenService tokenService,
		IUserAccessor userAccessor)
		: base(databaseContext, dbConnection, dispatcher, userAccessor)
	{
		_tokenService = tokenService;
	}

	[AllowAnonymous]
	[HttpPost("Login")]
	public async Task<IActionResult> LoginAccount([FromBody] LoginRequest request, CancellationToken cancellationToken)
	{
		// Creating the command
		var command = new LoginCommand(request.Login, request.Password);

		// Sending the request to the handler
		var userRequest = await _dispatcher.Send<LoginCommand, LoginUserResultDTO>(command, cancellationToken);

		// Validate the request
		if (userRequest is { IsFailure: true })
			return BadRequest(userRequest.Error);

		// Get the User
		var userResponse = userRequest.Value;

		// Validate the userResponse
		if (userResponse is null)
			return BadRequest(userResponse);

		// Generating the token
		var token = _tokenService.GenerateToken(userResponse);

		return Ok(Result.Success<string>(token));
	}

	[AllowAnonymous]
	[HttpPost("Register")]
	public async Task<IActionResult> RegisterAccount([FromBody] RegisterRequest request, CancellationToken cancellationToken)
	{
		// Building the DTO
		var userDto = new UserDTO(
			request.Login, 
			request.Email, 
			request.Password, 
			request.Name, 
			request.Surname, 
			request.Image, 
			request.Phone);

		// Creating the command
		var command = new RegisterCommand(userDto);

		// Sending the request to the handler
		var userRequest = await _dispatcher.Send<RegisterCommand, bool>(command, cancellationToken);

		// Validating the request
		if (userRequest is { IsFailure: true })
			return BadRequest(userRequest.Error);

		// Get the user
		var userResponse = userRequest.Value;

		// Validate the userResponse
		if (userResponse is false)
			return BadRequest("An error occoured.");

		return Ok(Result.Success<bool>(true));
	}
}
