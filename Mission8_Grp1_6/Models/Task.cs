using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Grp1_6.Models
{
    public class Task
    {
        [Key]
        
        public int TaskID { get; set; }

        public string TaskName { get; set; }

        public DateTime? DueDate { get; set; }

        public int Quadrant { get; set; }

        public string? Category { get; set; }

        public bool? Completed { get; set; }
    }
}
