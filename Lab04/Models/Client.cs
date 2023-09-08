using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Lab04.Models
{
    public class Client
    {

        [Key]
        public int ID { get; set; }

        [Required] 
        [DisplayName("First Name")]
        [MaxLength(25)]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required] 
        [DisplayName("Last Name")]
        [MaxLength(25)]
        [MinLength(3)]
        public string LastName { get; set; }

        private string _phoneNumber;

        [Required] 
        [DisplayName("Phone Number")]
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (value != null && Regex.IsMatch(value, @"^\d{10}$"))
                {
                    _phoneNumber = value;
                }
                else 
                { 
                    throw new ArgumentException("Invalid phone number format.");
                }
            }
        }
    }
}
