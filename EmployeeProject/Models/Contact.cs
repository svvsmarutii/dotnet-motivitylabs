using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EmployeeProject.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your EmployeeId")]
        public long EmployeeId { get; set; }
        [Required(ErrorMessage = "Please enter your MobileCountryCode")]
        public byte MobileCountryCode { get; set; }
        [Required(ErrorMessage = "Please enter your Mobile")]
        public long Mobile { get; set; }
        public byte? AlternateMobileCountryCode { get; set; }
        public long? AlternateMobile { get; set; }
        public byte? WorkNumberCountryCode { get; set; }
        public long? WorkNumber { get; set; }
        public byte? WorkExtension { get; set; }
        public byte? HomeCountryCode { get; set; }
        public long? HomeNumber { get; set; }
        public byte? HomeExtension { get; set; }
        public byte? CompanyMobileCountryCode { get; set; }
        public long? CompanyMobile { get; set; }
        public bool Active { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
