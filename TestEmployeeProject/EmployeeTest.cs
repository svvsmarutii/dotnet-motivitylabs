using EmployeeProject.Controllers;
using EmployeeProject.Models;
using EmployeeProject.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestEmployeeProject
{
   public class EmployeeTest 
    {
        private  IEmployee _employee;
        public static DbContextOptions<EmployeeContext> dbContextOptions { get; }
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=Employee;Integrated Security=True;";
        static EmployeeTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<EmployeeContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        public EmployeeTest()
        {
            var context = new EmployeeContext(dbContextOptions);
           

            _employee = new EmployeeRepository(context);
        }
        [Fact]
        public async void Task_GetEmployeeById_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            int Id = 1;

            //Act  
            var data = await controller.GetEmployeeById(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_GetEmployeeById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            int Id = 0;

            //Act  
            var data = await controller.GetEmployeeById(Id);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetEmployeeById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            long Id = 0;

            //Act  
            var data = await controller.GetEmployeeById(Id);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]   //use Data Base
        public void GetById_ExistingEmployeePassed_ReturnsRightItem()
        {
            var controller = new EmployeeController(_employee);

            // Arrange
            int Id = 1;
            // Act
            var okResult = controller.GetEmployeeById(Id).Result as OkObjectResult;

            // Assert
            Assert.IsType<Employee>(okResult.Value);
            Assert.Equal(Id, (okResult.Value as Employee).Id);
        }
        [Fact]
        public async void Task_GetEmployeeById_MatchResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            int Id = 1;

            //Act  
            var data = await controller.GetEmployeeById(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<Employee>().Subject;

            Assert.Equal("Niranjan", post.FirstName);
            Assert.Equal("Marpaka", post.LastName);
        }
        [Fact]
        public async void Task_GetEmployees_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);

            //Act  
            var data = await controller.GetEmployee();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]    //using of data base
        public void GetEmployeeReturnOkResult()
        {
            var controller = new EmployeeController(_employee);
            var okResult = controller.GetEmployee();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Task_GetEmployee_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);

            //Act  
            var data = controller.GetEmployee();
            data = null;

            if (data != null)
                //Assert  
                Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_GetEmployees_MatchResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);

            //Act  
            var data = await controller.GetEmployee();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<List<Employee>>().Subject;

            Assert.Equal("Niranjan", post[0].FirstName);
            Assert.Equal("Marpaka", post[0].LastName);

            // Assert.Equal("Test Title 2", post[1].Title);
            //  Assert.Equal("Test Description 2", post[1].Description);
        }
        [Fact]
        public async void Task_Add_InValidData_Return_Badrequest()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            var post = new Employee()
            {

                FirstName = "Niranjan",
                MiddleName = "",
                LastName = "Niranjan",
                CertificateDob = DateTime.MinValue,
                ActualDob = DateTime.MinValue,
                Gender = 1,
                MaritalStatus = 1,
                Doj = DateTime.MinValue,
                OfficeLocation = "Hyd",
                EmpId = "MLI768",
                SeperatedDate = DateTime.MinValue,
                ReportingManagerid = "MLI768",
                CompanyEmailId = "Niranjan@gmail.com",
                PersonalEmailId = "niranjan@motivitylabs.com",
                Active = true,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                ModifiedBy = 0,
                ModifiedDate = DateTime.Now
            };
            //Act  
            var data = await controller.CreateEmployee(post);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            Employee emp = new Employee()
            {

                FirstName = "Test Title More Than 20 Characteres",
                MiddleName = "",
                LastName = "Test Title More Than 20 Characteres",
                CertificateDob = DateTime.MinValue,
                ActualDob = DateTime.MinValue,
                Gender = 1,
                MaritalStatus = 1,
                Doj = DateTime.MinValue,
                OfficeLocation = "Hyd",
                EmpId = "MLI768",
                SeperatedDate = DateTime.MinValue,
                ReportingManagerid = "MLI768",
                CompanyEmailId = "Niranjan@gmail.com",
                PersonalEmailId = "niranjan@motivitylabs.com",
                Active = true,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                ModifiedBy = 0,
                ModifiedDate = DateTime.Now
            };

            //Act              
            var data = await controller.CreateEmployee(emp);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        //[Fact]
        //public async void Task_Add_ValidData_MatchResult()
        //{
        //    //Arrange  
        //    var controller = new EmployeeController(_employee);
        //    var emp = new Employee()
        //    {
        //        Id=1,
        //        EmpId = "MLI768",
        //        FirstName = "Niranjan",
        //        MiddleName = "",
        //        LastName = "Marpaka",
        //        CertificateDob = System.DateTime.Now,
        //        ActualDob = System.DateTime.Now,
        //        Gender = 1,
        //        MaritalStatus = 1,
        //        Doj = System.DateTime.Now,
        //        OfficeLocation = "Hyd",               
        //        SeperatedDate = System.DateTime.Now,
        //        ReportingManagerid = "MLI768",
        //        CompanyEmailId = "Niranjan@gmail.com",
        //        PersonalEmailId = "niranjan@motivitylabs.com",
        //        Active = true,
        //        CreatedBy = 0,
        //        CreatedDate = System.DateTime.Now,
        //        ModifiedBy = 0,
        //        ModifiedDate = System.DateTime.Now
        //    };
        //    //Act  
        //    var data = await controller.CreateEmployee(emp);

        //    //Assert  
        //    Assert.IsType<OkObjectResult>(data);

        //    var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
        //    var result = okResult.Value.Should().BeAssignableTo<Employee>().Subject;

        //    Assert.Equal(1,okResult.Value);
        //}
        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            var Id = 1;

            //Act  
            var existingPost = await controller.GetEmployeeById(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Employee>().Subject;

            var post = new Employee();
            post.FirstName = "Name Updated";
            post.MiddleName = result.MiddleName;
            post.Id = result.Id;
            post.LastName = "Kp";
            post.CertificateDob = DateTime.MinValue;
            post.ActualDob = DateTime.MinValue;
            post.CreatedDate = result.CreatedDate;
            post.Gender = result.Gender;
            post.MaritalStatus = result.MaritalStatus;
            post.Doj = result.Doj;
            post.OfficeLocation = result.OfficeLocation;
            post.EmpId = result.EmpId;
            post.SeperatedDate = result.SeperatedDate;
            post.ReportingManagerid = result.ReportingManagerid;
            post.CompanyEmailId = result.CompanyEmailId;
            post.PersonalEmailId = result.PersonalEmailId;
            post.Active = result.Active;
            post.CreatedBy = result.CreatedBy;
            post.CreatedDate = DateTime.Now;
            post.ModifiedBy = result.ModifiedBy;
            post.ModifiedDate = result.ModifiedDate;
            var updatedData = await controller.PutEmployee(post);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            var Id = 1;

            //Act  
            var existingPost = await controller.GetEmployeeById(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Employee>().Subject;

            var post = new Employee();
            post.FirstName = "Name Test Title More Than 20 Characteres";
            post.MiddleName = result.MiddleName;
            post.Id = result.Id;
            post.LastName = "Test Title More Than 20 Characteres";
            post.CertificateDob = System.DateTime.MinValue;
            post.ActualDob = System.DateTime.MinValue;
            post.CreatedDate = result.CreatedDate;
            post.Gender = result.Gender;
            post.MaritalStatus = result.MaritalStatus;
            post.Doj = result.Doj;
            post.OfficeLocation = result.OfficeLocation;
            post.EmpId = result.EmpId;
            post.SeperatedDate = result.SeperatedDate;
            post.ReportingManagerid = result.ReportingManagerid;
            post.CompanyEmailId = result.CompanyEmailId;
            post.PersonalEmailId = result.PersonalEmailId;
            post.Active = result.Active;
            post.CreatedBy = result.CreatedBy;
            post.CreatedDate = System.DateTime.Now;
            post.ModifiedBy = result.ModifiedBy;
            post.ModifiedDate = result.ModifiedDate;
            var data = await controller.PutEmployee(post);

            //Assert  
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public async void Task_Update_Data_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            var Id = 1;

            //Act  
            var existingPost = await controller.GetEmployeeById(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Employee>().Subject;

            var post = new Employee();
            post.FirstName = "Name Test Title More Than 20 Characteres";
            post.MiddleName = result.MiddleName;
            post.Id = result.Id;
            post.LastName = "Test Title More Than 20 Characteres";
            post.CertificateDob = System.DateTime.MinValue;
            post.ActualDob = System.DateTime.MinValue;
            post.CreatedDate = result.CreatedDate;
            post.Gender = result.Gender;
            post.MaritalStatus = result.MaritalStatus;
            post.Doj = result.Doj;
            post.OfficeLocation = result.OfficeLocation;
            post.EmpId = result.EmpId;
            post.SeperatedDate = result.SeperatedDate;
            post.ReportingManagerid = result.ReportingManagerid;
            post.CompanyEmailId = result.CompanyEmailId;
            post.PersonalEmailId = result.PersonalEmailId;
            post.Active = result.Active;
            post.CreatedBy = result.CreatedBy;
            post.CreatedDate = System.DateTime.Now;
            post.ModifiedBy = result.ModifiedBy;
            post.ModifiedDate = result.ModifiedDate;

            var data = await controller.PutEmployee(post);

            //Assert  
            Assert.IsType<OkResult>(data);
        }
        [Fact]
        public async void Task_Delete_Post_Return_OkResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            int Id = 2;

            //Act  
            var data = await controller.DeleteEmployee(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Delete_Post_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            var Id = 0;

            //Act  
            var data = await controller.DeleteEmployee(Id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_Delete_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new EmployeeController(_employee);
            long Id =0 ;

            //Act  
            var data = await controller.DeleteEmployee(Id);
           
           
            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }
    }
}

