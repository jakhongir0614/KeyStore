using System.ComponentModel.DataAnnotations;

namespace KeyStore.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name of the User is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email of the user is required!")]

        public string Email { get; set; }
    }
}
