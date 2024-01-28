using System.ComponentModel.DataAnnotations;

namespace TestEpsiTech.Models.DTOs
{
    public class TaskDto
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Name not specified")]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
