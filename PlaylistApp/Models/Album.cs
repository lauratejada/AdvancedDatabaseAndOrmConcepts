using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaylistApp.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Year must not be negative.")]
        public int Year { get; set; }

        // Navigation property
        public virtual ICollection<Song> Songs { get; set; }
    }
}
