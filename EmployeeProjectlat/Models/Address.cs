using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EmployeeProject.Models
{
    
    public partial class Address
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your EmployeeId")]
        public long EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter your Type")]
        public bool Type { get; set; }
        [Required(ErrorMessage = "Please enter your Line1")]

        public string Line1 { get; set; }
        [Required(ErrorMessage = "Please enter your Line2")]
        public string Line2 { get; set; }
        [Required(ErrorMessage = "Please enter your City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter your State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter your Country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter your Zipcode")]
        public string Zipcode { get; set; }
        [Required(ErrorMessage = "Please enter your Active")]
        public bool Active { get; set; }
        [Required(ErrorMessage = "Please enter your CreatedBy")]
        public long CreatedBy { get; set; }
        [Required(ErrorMessage = "Please enter your CreatedDate")]
        //[DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
