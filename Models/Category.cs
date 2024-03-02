using System.ComponentModel.DataAnnotations;

namespace Mission08_Group3_11.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
    }
}
