using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0315.Models
{
    public class ToDoListForm
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        public string TaskName { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
      
        public QuadrantCategory? Category {  get; set; }  

        public string? DueDate { get; set; }

        [Required]
        public int Quadrant { get; set; }

        public bool? Completed { get; set; }

        public static implicit operator Task(ToDoListForm v)
        {
            throw new NotImplementedException();
        }
    }
}
