using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.API.Contracts;
using Tryitter.API.Data;
using Tryitter.API.Models.User;

namespace Tryitter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            this._mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();
            var usersList = _mapper.Map<List<GetUserDto>>(users);
            
            return Ok(usersList);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDetailsDto>> GetUser(int id)
        {
            var user = await _userRepository.GetDetails(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var userDto = _mapper.Map<GetUserDetailsDto>(user);

            return Ok(userDto);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.Id)
            {
                return BadRequest("Invalid user id");
            }

            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            _mapper.Map(updateUserDto, user);

            try
            {
                await _userRepository.UpdateAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UserExists(id))
                {
                    return NotFound("User not found");
                }
                else
                {
                    throw;
                }
            }
            
            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetUserDetailsDto>> PostUser(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            await _userRepository.AddAsync(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetAsync(id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            await _userRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> UserExists(int id)
        {
            return await _userRepository.Exists(id);
        }
    }
}
