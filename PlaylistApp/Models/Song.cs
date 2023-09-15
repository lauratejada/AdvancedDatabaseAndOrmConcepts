using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaylistApp.Models
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Title { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Length must be a positive integer.")]
        public int LengthInSeconds { get; set; }

        // Foreign Key
        [ForeignKey(nameof(Playlist))]
        public int PlaylistID { get; set; }

        // Foreign Key
        [ForeignKey(nameof(Album))]
        public int AlbumID { get; set; }

        // Navigation properties
        public virtual Album Album { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
