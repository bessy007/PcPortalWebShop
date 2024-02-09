using System.ComponentModel.DataAnnotations;

namespace PCPortal.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Full name is required.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Your phone number is required.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Message is required.")]
        public string Message { get; set; }
    }
}
