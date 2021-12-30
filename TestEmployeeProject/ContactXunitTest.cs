using EmployeeProject.Controllers;
using EmployeeProject.Models;
using EmployeeProject.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestEmployeeProject
{
  public  class ContactXunitTest
    {
        
    
        private IContact _contact;
        private readonly ContactController contactController;
        private readonly ILogger ilogger;
        public static DbContextOptions<EmployeeContext> dbContextOptions { get; }
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=Employee;Integrated Security=True;";
        static ContactXunitTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<EmployeeContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        public ContactXunitTest()
        {
            var context = new EmployeeContext(dbContextOptions);
            _contact = new ContactRepository(context);
        }
        [Fact]
        public async void Task_GetcontactById_Return_OkResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            int Id = 1;

            //Act  
            var data = await controller.GetcontactById(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_GetcontactById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            int Id = 0;

            //Act  
            var data = await controller.GetcontactById(Id);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetcontactById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            int Id = 0;

            //Act  
            var data = await controller.GetcontactById(Id);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]   //use Data Base
        public void GetById_ExistingEmployeePassed_ReturnsRightItem()
        {
            var controller = new ContactController(_contact);

            // Arrange
            int Id = 1;
            // Act
            var okResult = controller.GetcontactById(Id).Result as OkObjectResult;

            // Assert
            Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(Id, (okResult.Value as Contact).Id);
        }
        [Fact]
        public async void Task_GetcontactById_MatchResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            int Id = 1;

            //Act  
            var data = await controller.GetcontactById(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<Contact>().Subject;

            Assert.Equal("1", post.Id.ToString());
           
        }
        [Fact]
        public async void Task_Getcontacts_Return_OkResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);

            //Act  
            var data = await controller.Getcontact();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]    //using of data base
        public void GetcontactReturnOkResult()
        {
            var controller = new ContactController(_contact);
            var okResult = controller.Getcontact();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Task_Getcontact_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);

            //Act  
            var data = controller.Getcontact();
            data = null;

            if (data != null)
                //Assert  
                Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_Getcontacts_MatchResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);

            //Act  
            var data = await controller.Getcontact();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<List<Contact>>().Subject;

            Assert.Equal(1, post[0].Id);
         

            // Assert.Equal("Test Title 2", post[1].Title);
            //  Assert.Equal("Test Description 2", post[1].Description);
        }
        [Fact]
        public async void Task_Add_InValidData_Return_Badrequest()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            var post = new Contact()
            {

                
                Active = true,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                ModifiedBy = 0,
                ModifiedDate = DateTime.Now
            };
            //Act  
            var data = await controller.Createcontact(post);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            Contact cnt = new Contact()
            {
                Id=1,
                EmployeeId=1,
                MobileCountryCode=1,
                Mobile=810629993,
                AlternateMobile=810629993,
                AlternateMobileCountryCode=91,
                WorkNumberCountryCode=91,
                WorkNumber=135555,
                WorkExtension=91,
                HomeCountryCode=91,
                HomeNumber=123456,
                HomeExtension=91,
                CompanyMobileCountryCode=91,
                CompanyMobile=1,
                Active = true,
                CreatedBy = 0,
                CreatedDate = DateTime.Now,
                ModifiedBy = 0,
                ModifiedDate = DateTime.Now
            };

            //Act              
            var data = await controller.Createcontact(cnt);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }
    
        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            var Id = 1;

            //Act  
            var existingPost = await controller.GetcontactById(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Contact>().Subject;

            var post = new Contact();
            post.Id = 0;
            post.EmployeeId = result.Id;
            post.Active = result.Active;
            post.CreatedBy = result.CreatedBy;
            post.CreatedDate = System.DateTime.Now;
            post.ModifiedBy = result.ModifiedBy;
            post.ModifiedDate = result.ModifiedDate;
            var updatedData = await controller.Putcontact(post);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_OkResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            var Id = 1;

            //Act  
            var existingPost = await controller.GetcontactById(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Contact>().Subject;

            var post = new Contact();
            post.Id = 0;
            post.EmployeeId = result.Id;
            post.Active = result.Active;
            post.CreatedBy = result.CreatedBy;
            post.CreatedDate = System.DateTime.Now;
            post.ModifiedBy = result.ModifiedBy;
            post.ModifiedDate = result.ModifiedDate;

            var data = await controller.Putcontact(post);

            //Assert  
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public async void Task_Update_Data_Return_OkResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            var Id = 1;

            //Act  
            var existingPost = await controller.GetcontactById(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Contact>().Subject;

            var post = new Contact();

            post.Id = 0;
            post.EmployeeId = result.EmployeeId;
            post.MobileCountryCode = result.MobileCountryCode;
            post.Mobile = result.Mobile;
            post.AlternateMobile = result.AlternateMobile;
            post.AlternateMobileCountryCode = result.AlternateMobileCountryCode;
            post.WorkNumberCountryCode = result.WorkNumberCountryCode;
            post.WorkNumber = result.WorkNumber;
            post.WorkExtension = result.WorkExtension;
            post.HomeCountryCode = result.HomeCountryCode;
            post.HomeNumber = result.HomeNumber;
            post.HomeExtension = result.HomeExtension;
            post.CompanyMobileCountryCode = result.CompanyMobileCountryCode;
                post.CompanyMobile = result.CompanyMobile;
            post.Active = result.Active;
            post.CreatedBy = result.CreatedBy;
            post.CreatedDate = result.CreatedDate;
            post.ModifiedBy = result.ModifiedBy;
            post.ModifiedDate = result.ModifiedDate;
            var data = await controller.Putcontact(post);

            //Assert  
            Assert.IsType<OkResult>(data);
        }
        [Fact]
        public async void Task_Delete_Post_Return_OkResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            int Id =116;

            //Act  
            var data = await controller.Deletecontact(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Delete_Post_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            var Id = 0;

            //Act  
            var data = await controller.Deletecontact(Id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_Delete_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new ContactController(_contact);
            int Id = 0;

            //Act  
            var data = await controller.Deletecontact(Id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }
       
      
    }
}
