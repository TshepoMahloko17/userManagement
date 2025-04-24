using System.ComponentModel.DataAnnotations;

namespace userManagement.Dtos
{
    public class AddUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
