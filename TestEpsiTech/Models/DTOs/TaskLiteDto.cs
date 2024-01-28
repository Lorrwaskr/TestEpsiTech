using System.ComponentModel.DataAnnotations;

namespace TestEpsiTech.Models.DTOs
{
    public class TaskLiteDto
    {
        [Required(ErrorMessage = "Name not specified")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
