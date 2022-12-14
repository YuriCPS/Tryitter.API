using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.API.Contracts;
using Tryitter.API.Data;
using Tryitter.API.Models.User;

namespace Tryitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthManager _authManager;
        private readonly IMapper _mapper;

        public AccountController(IUserRepository userRepository, IAuthManager authManager, IMapper mapper)
        {
            _userRepository = userRepository;
            _authManager = authManager;
            _mapper = mapper;
        }

        // POST: api/Register
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> RegisterUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (await _userRepository.GetByEmail(createUserDto.Email) != null)
            {
                return BadRequest("User with this email already exists");
            }

            if (await _userRepository.GetByUserName(createUserDto.UserName) != null)
            {
                return BadRequest("User with this username already exists");
            }

            var userToCreate = _mapper.Map<User>(createUserDto);
            await _userRepository.AddAsync(userToCreate);

            return Ok(userToCreate);
        }

        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<AuthUserResponseDto>> LoginUser([FromBody] LoginUserDto loginUserDto)
        {
            var authResponse = await _authManager.Login(loginUserDto);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }
    }
}
