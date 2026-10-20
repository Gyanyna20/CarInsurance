using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsurance.Models
{
    [Table("Insurees")]
    public class Insuree
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, EmailAddress, StringLength(50)]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }

        [Required, Range(1886, 2100)]
        public int CarYear { get; set; }

        [Required, StringLength(50)]
        public string CarMake { get; set; }

        [Required, StringLength(50)]
        public string CarModel { get; set; }

        public bool DUI { get; set; }

        [Required, Range(0, 100)]
        public int SpeedingTickets { get; set; }

        public bool CoverageType { get; set; }

        [Column(TypeName = "money")]
        public decimal Quote { get; set; }
    }
}
