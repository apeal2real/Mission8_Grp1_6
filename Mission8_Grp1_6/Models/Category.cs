using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8_Grp1_6.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string? CategoryName { get; set; }
    }
}
