using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Group3_11.Models
{
    public class Application

    {
        public int TaskId { get; set; }
        public int Task { get; set; }
        public int DueDate { get; set; }
        public int Quadrant { get; set; }
        public string Category { get; set; }
        public bool Completed { get; set; }
        
    }
}
