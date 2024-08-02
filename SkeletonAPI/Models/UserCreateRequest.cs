using System.ComponentModel.DataAnnotations;

namespace SkeletonAPI.Models
{
    public class UserCreateRequest
    {
        [Required]
        public string _id { get; set; }

        [Required]
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
    }
}
