using Tryitter.API.Models.User;

namespace Tryitter.API.Contracts
{
    public interface IAuthManager
    {
        Task<AuthUserResponseDto> Login(LoginUserDto loginUserDto);

        //Task<bool> VerifyUser(int id, string token);
    }
}
