using System.ComponentModel.DataAnnotations;

namespace ReservaSala.Api.Models
{
    class EditEmployeeModel
    {
        public string Email { get; set; }
        [CompareProperty("Email",
            ErrorMessage = "Email and Confirm Email must match")]
        public string ConfirmEmail { get; set; }
    }
}
