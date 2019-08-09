using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MitraisCodingTest.Core.Models
{
    [Table("UserRegistration")]
    public class User : BaseModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("UserId")]
        public override int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string MobileNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

    }
}
