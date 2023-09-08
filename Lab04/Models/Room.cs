using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab04.Models
{
    public class Room
    {

        [Key]
        [DisplayName("Room Number")]
        public int RoomNumber { get; set; }

        private int _capacity;

        [DisplayName("Capacity of Tenants")]
        [Range(1, 6, ErrorMessage = "Capacity must be between 1 and 6.")]
        public int Capacity
        {
            get => _capacity;
            set
            {
                if ( value < 1 || value > 6)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Capacity must be between 1 and 6.");
                }
                else
                {
                    _capacity = value;
                }
            }
        }

        [DisplayName("Section")]
        public RoomSection Section { get; set; }
    }

    public enum RoomSection
    {
        First,
        Second,
        Third
    }
}
