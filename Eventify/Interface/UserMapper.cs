using Eventify.DTOs.User.Output;
namespace Eventify.Interface
{
    public class UserMapper
    {
        public static GetUserDTO ToGetUserDTO(Models.User user, string role)
        {
            return new GetUserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Role = role
            };
        }
    }
}
