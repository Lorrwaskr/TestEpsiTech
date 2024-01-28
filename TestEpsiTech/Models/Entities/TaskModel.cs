using System.ComponentModel.DataAnnotations;

namespace TestEpsiTech.Models.Entities
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime CreationDate { get; set; }
        [Required]
        public DateTime LastUpdateDate { get; set;}
    }
}
