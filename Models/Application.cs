using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Group3_11.Models
{
    public class Application

    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required]
        public string Task { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; } = DateTime.Today.AddDays(1);
        [Required]
        [Range(1,4, ErrorMessage = "Quadrant must be a number between 1 and 4")]
        public int Quadrant { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool Completed { get; set; }
        
    }
}
