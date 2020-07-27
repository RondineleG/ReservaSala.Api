using System.ComponentModel.DataAnnotations;

namespace ReservaSala.Api.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}