using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using EmployeeProject.Models;
using EmployeeProject.Controllers;
using EmployeeProject.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net;

using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TestEmployeeProject
{
    public class EmployeeModelTest
    {


        #region Test_Employee_FirstName_Fail_Case
        [Fact]
        public Task Test_Employee_FirstName_Fail_Case()
        {
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                //FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "Niranjan@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            ModelValidator modelValidator = new ModelValidator();
            var result= modelValidator.Validations(emp);
            //var result = new List<ValidationResult>();
            //var validationContext = new ValidationContext(emp);
            //Validator.TryValidateObject(emp, validationContext, result);
            Assert.Equal(("Please enter your FirstName"), result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion

       

        #region Test_Employee_LastName_Fail_Case
        [Fact]
        public Task Test_Employee_LastName_Fail_Case()
        {
            //Arrange
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "Niranjan",
                MiddleName = "",
                //LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "Niranjan@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            //Act
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);
            //Assert
            Assert.Equal(("Please enter your LastName"), result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_CertificateDob_Fail_Case
        [Fact]
        public Task Test_Employee_CertificateDob_Fail_Case()
        {
            //Arrange
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                //CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "Niranjan@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            //Act
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
        
            Validator.TryValidateObject(emp, validationContext, result);

            //Assert
            Assert.NotNull(result);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_ActualDob_Fail_Case
        [Fact]
        public Task Test_Employee_ActualDob_Fail_Case()
        {
            //Arrange 
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                //ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "Niranjan@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            //Act
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            //Assert
            Assert.NotNull(result);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_Doj_Fail_Case
        [Fact]
        public Task Test_Employee_Doj_Fail_Case()
        {
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                //Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "Niranjan@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            //Assert
            Assert.NotNull(result);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_Gender_Fail_Case
        [Fact]
        public Task Test_Employee_Gender_Fail_Case()
        {
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                //Gender =  1,
                ReportingManagerid = "Niranjan@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);
            //Assert
            Assert.NotNull(result);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_ReportingManagerid_Fail_Case
        [Fact]
        public Task Test_Employee_ReportingManagerid_Fail_Case()
        {
            //Arrange
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                //ReportingManagerid = "Niranjan@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            //Act
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);
            //Assert
            Assert.Equal(("Please enter your ReportingManagerid"), result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion

        #region Test_Employee_OfficeLocation_Fail_Case
        [Fact]
        public Task Test_Employee_OfficeLocation_Fail_Case()
        {
            //Arrange
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "Niranjan@motivitylabs.com",
                //OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            //Act
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);

            //Assert
            Assert.Equal(("Please enter your OfficeLocation"), result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion



        #region Test_Employee_CompanyEmailId_Fail_Case
        [Fact]
        public Task Test_Employee_CompanyEmailId_Fail_Case()
        {
            //Arrange
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "Niranjan@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                //CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            //Act
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp,validationContext,result);
            //Assert
            Assert.Equal("Please enter your CompanyEmailId", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion,

        #region Test_Employee_PersonalEmailId_Fail_Case
        [Fact]
        public Task Test_Employee_PersonalEmailId_Fail_Case()
        {
            //Arrange
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "Niranjan@motivitylabs.com",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                //PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            //Act
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp);
            Validator.TryValidateObject(emp, validationContext, result);
            //Assert
            Assert.Equal(("Please enter your PersonalEmailId"), result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion    

        #region Test_Employee_LastName_Success_Case
        [Fact]
        public Task Test_Employee_LastName_Success_Case()
        {
            //Arrange
            var emp = new Employee
            {
                LastName = "Marpaka"
            };
            //Act
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp) { MemberName= "LastName" };
           bool correct= Validator.TryValidateProperty(emp.LastName, validationContext, result);
            //Assert
            Assert.NotNull(result);
            return Task.CompletedTask;
        }
        #endregion
        #region Test_Employee_FirstName_Mini3Max20charecters_ReturnFailCase
        [Fact]
        public Task Test_Employee_FirstName_Mini3Max20charecters_ReturnFailCase()
        {
            var emp = new Employee
            {
                FirstName="1",
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp)
            {
                MemberName = "FirstName"
            };
            Validator.TryValidateProperty(emp.FirstName, validationContext, result);
            Assert.Equal("First Name should be minimum  3 characters and a maximum of 20 characters", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
        #region Test_Employee_ReportingManagerID_Mini3Max20charecters_ReturnFailCase
        [Fact]
        public Task Test_Employee_ReportingManagerID_Mini3Max20charecters_ReturnFailCase()
        {
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "n",
                OfficeLocation = "h",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp)
            {
                MemberName = "ReportingManagerid"
            };
            bool correct = Validator.TryValidateObject(emp, validationContext,result);
            bool value = Validator.TryValidateProperty(emp.ReportingManagerid, validationContext, result);
            Assert.Equal("ReportingManagerId should be minimum 5 characters and a maximum of 50 characters", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
        #region Test_Employee_OfficeLocation_Mini3Max20charecters_ReturnFailCase
        [Fact]
        public Task Test_Employee_OfficeLocation_Mini3Max20charecters_ReturnFailCase()
        {
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "MLI710",
                OfficeLocation = "h",
                Active = true,
                CompanyEmailId = "niranjan@motivitylabs.com",
                PersonalEmailId = "niranjan@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp)
            {
                MemberName = "OfficeLocation"
            };
        
            bool value = Validator.TryValidateProperty(emp.OfficeLocation, validationContext, result);
            Assert.Equal("OfficeLocation should be minimum 5 characters and a maximum of 50 characters", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
        #region Test_Employee_CompanyEmailId_Mini3Max20charecters_ReturnFailCase
        [Fact]
        public Task Test_Employee_CompanyEmailId_Mini3Max20charecters_ReturnFailCase()
        {
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "MLI710",
                OfficeLocation = "hyd",
                Active = true,
                CompanyEmailId = "n",
                PersonalEmailId = "ni@gmail.com",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp)
            {
                MemberName = "CompanyEmailId"
            };
            bool value = Validator.TryValidateProperty(emp.CompanyEmailId, validationContext, result);
            Assert.Equal("Company EmailId should be minimum 5 characters and a maximum of 50 characters", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
        #region Test_Employee_PersonalEmailId_Mini3Max20charecters_ReturnFailCase
        [Fact]
        public Task Test_Employee_PersonalEmailId_Mini3Max20charecters_ReturnFailCase()
        {
            var emp = new Employee
            {
                Id = 1,
                EmpId = "MLI768",
                FirstName = "niranjan",
                MiddleName = "",
                LastName = "Marpaka",
                CertificateDob = DateTime.Parse("2021-10-10"),
                ActualDob = DateTime.Parse("2021-10-10"),
                Doj = DateTime.Parse("2021-10-10"),
                Gender = 1,
                ReportingManagerid = "MLI710",
                OfficeLocation = "Hyderabad",
                Active = true,
                CompanyEmailId = "niranjan@gmail.com",
                PersonalEmailId = "n",
                SeperatedDate = DateTime.Parse("2021-10-10"),
                MaritalStatus = 1,
                CreatedBy = 768,
                CreatedDate = DateTime.Now,
                ModifiedBy = 768,
                ModifiedDate = DateTime.Now
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(emp)
            {
                MemberName = "PersonalEmailId"
            };
            bool value = Validator.TryValidateProperty(emp.PersonalEmailId, validationContext, result);
            Assert.Equal("Personal EmailId should be minimum 5 characters and a maximum of 50 characters", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion        

    }
}




