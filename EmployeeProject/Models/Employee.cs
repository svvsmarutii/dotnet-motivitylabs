using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EmployeeProject.Models
{
    public partial class Employee
    {       
        public Employee()
        {
            Addresses = new HashSet<Address>();
            Contacts = new HashSet<Contact>();
        }
       
        public long Id { get; set; }


        [Required(ErrorMessage = "Please enter your EmpId")]
        public string EmpId { get; set; }


        [Required(ErrorMessage = "Please enter your FirstName")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name should be minimum  3 characters and a maximum of 20 characters")]
        public string FirstName { get; set; }



        public string MiddleName { get; set; }



        [Required(ErrorMessage = "Please enter your LastName")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Please enter your CertificateDob")]
        
        [DataType(DataType.DateTime)]
        public DateTime CertificateDob { get; set; }



        [DataType(DataType.DateTime)]
        public DateTime? ActualDob { get; set; }


        [Required(ErrorMessage = "Please enter your Doj")]
        [DataType(DataType.DateTime)]
        public DateTime Doj { get; set; }


        [Required(ErrorMessage = "Please enter your Gender")]
        public byte Gender { get; set; }

        [Required(ErrorMessage = "Please enter your ReportingManagerid")]
        [Display(Name = "ReportingManagerID", Prompt = "Enter ReportingManagerId", Description = "Please Enter ReportingManagerId")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "ReportingManagerId should be minimum 5 characters and a maximum of 50 characters")]
        public string ReportingManagerid { get; set; }


        [Required(ErrorMessage = "Please enter your OfficeLocation")]
        [Display(Name = "OfficeLocation", Prompt = "Enter OfficeLocation", Description = "Please Enter OfficeLocation")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "OfficeLocation should be minimum 5 characters and a maximum of 50 characters")]
        public string OfficeLocation { get; set; }

        [Required(ErrorMessage = "Please enter your Active")]
        [Display(Name = "Active", Prompt = "Is Active", Description = "Please check if Active Employee")]
        public bool Active { get; set; }

        [Required(ErrorMessage = "Please enter your CompanyEmailId")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "CompanyEmailId", Prompt = "Enter Company EmailId", Description = "Please Enter Company EmailId")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Company EmailId should be minimum 5 characters and a maximum of 50 characters")]
        public string CompanyEmailId { get; set; }


        [Required(ErrorMessage = "Please enter your PersonalEmailId")]
        [Display(Name = "PersonalEmailId", Prompt = "Enter Personal EmailId", Description = "Please Enter Personal EmailId")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Personal EmailId should be minimum 5 characters and a maximum of 50 characters")]
        [DataType(DataType.EmailAddress)]
        public string PersonalEmailId { get; set; }


        [Display(Name = "SeperatedDate", Prompt = "Enter SeperatedDate", Description = "Please Enter SeperatedDate")]
        [DataType(DataType.DateTime)]
        public DateTime? SeperatedDate { get; set; }


        [Required(ErrorMessage = "Please enter your MaritalStatus")]
        [Display(Name = "MaritalStatus", Prompt = "Enter your MaritalStatus", Description = "Please Enter your MaritalStatus")]
        public byte MaritalStatus { get; set; }


        [Required(ErrorMessage = "Please enter your CreatedBy")]
        [Display(Name = "CreatedBy", Prompt = "Enter CreatedBy", Description = "Please Enter CreatedBy")]
        public long CreatedBy { get; set; }


        [Required(ErrorMessage = "Please enter your CreatedDate")]
        [Display(Name = "CreatedDate", Prompt = "Enter CreatedDate", Description = "Please Enter CreatedDate")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }


        public long? ModifiedBy { get; set; }


        public DateTime? ModifiedDate { get; set; }

        
        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }

}
}
