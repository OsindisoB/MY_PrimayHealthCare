using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models
{
    public class Counsellors
    {
        [Key]
        public int CounsellorId { get; set; } 

        public string Name { get; set; }

    }
}
