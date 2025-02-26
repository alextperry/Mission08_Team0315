using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0315.Models
{
    public class QuadrantCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
