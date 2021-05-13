using ProjectManager.Services.Interfaces.DTO.Enums;
using ProjectManager.Storage.Enums;

namespace ProjectManager.Services.Interfaces.DTO.Users
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public UserRoleEnum Role { get; set; }
    }
}