using System;

namespace MitraisCodingTest.Core.Models
{
    public class User
    {
        public int ID { get; set; }

        public string MobileNumber { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Month { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }
    }
}
