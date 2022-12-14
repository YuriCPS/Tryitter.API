using AutoMapper;
using Tryitter.API.Contracts;
using Tryitter.API.Data;
using Tryitter.API.Models.User;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Tryitter.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthManager(IMapper mapper, IUserRepository userRepository, IConfiguration config)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<AuthUserResponseDto> Login(LoginUserDto loginUserDto)
        {
            var user = await _userRepository.GetByEmail(loginUserDto.Email);

            var authUser = Authenticate(user, loginUserDto);
            if (authUser != null)
            {
                var token = await GenerateToken(user);

                return new AuthUserResponseDto
                {
                    UserId = user.Id,
                    Token = token
                };                
            }

            return null;
        }

        private async Task<string> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.LastName),
                new Claim("userId", user.Id.ToString())
            };
            
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_config["Jwt:DurationInMinutes"])),
                signingCredentials: credentials

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(User user, LoginUserDto loginUserDto)
        {
            if (user == null || loginUserDto.Password != user.Password)
            {
                return null;
            }

            return user;
        }
    }
}
