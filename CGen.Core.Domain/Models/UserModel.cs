using System.ComponentModel.DataAnnotations;

namespace CGen.Core.Domain.Models
{
    public class UserModel : IUserModel
    {
        //[Required]
        public string FirstName { get; set; }
        //[Required]
        public string LastName { get; set; }
        //[Required]
        public string Username { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}