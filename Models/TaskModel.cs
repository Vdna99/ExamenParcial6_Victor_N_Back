using System.ComponentModel.DataAnnotations;

namespace BackTaskWeb.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }


        public string Description { get; set; }

        [Required]
        public DateTime DateLimit { get; set; }

        public string State { get; set; }

    }
}
