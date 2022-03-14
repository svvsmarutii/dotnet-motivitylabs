using EmployeeProject.Controllers;
using EmployeeProject.Models;
using EmployeeProject.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestEmployeeProject
{
    public class AddressXunitTest
    {


        private IAddress _address;
        public static DbContextOptions<EmployeeContext> dbContextOptions { get; }
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=Employee;Integrated Security=True;";
        static AddressXunitTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<EmployeeContext>()
                .UseSqlServer(connectionString)
                .Options;
        }
        public AddressXunitTest()
        {
            var context = new EmployeeContext(dbContextOptions);


            _address = new AddressRepository(context);
        }
        [Fact]
        public async void Task_GetAddressById_Return_OkResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            int Id = 8;

            //Act  
            var data = await controller.GetAddressById(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]
        public async void Task_GetAddressById_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            int Id = 0;

            //Act  
            var data = await controller.GetAddressById(Id);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetAddressById_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            int Id = 0;

            //Act  
            var data = await controller.GetAddressById(Id);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]   //use Data Base
        public void GetById_ExistingEmployeePassed_ReturnsRightItem()
        {
            var controller = new AddressController(_address);

            // Arrange
            int Id = 8;
            // Act
            var okResult = controller.GetAddressById(Id).Result as OkObjectResult;

            // Assert
            Assert.IsType<Address>(okResult.Value);
            Assert.Equal(Id, (okResult.Value as Address).Id);
        }
        [Fact]
        public async void Task_GetAddressById_MatchResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            int Id = 8;

            //Act  
            var data = await controller.GetAddressById(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<Address>().Subject;

            Assert.Equal(8, post.Id);
         
        }
        [Fact]
        public async void Task_GetAddresss_Return_OkResult()
        {
            //Arrange  
            var controller = new AddressController(_address);

            //Act  
            var data = await controller.GetAddress();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
        [Fact]    //using of data base
        public void GetAddressReturnOkResult()
        {
            var controller = new AddressController(_address);
            var okResult = controller.GetAddress();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }
        [Fact]
        public void Task_GetAddress_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new AddressController(_address);

            //Act  
            var data = controller.GetAddress();
            data = null;

            if (data != null)
                //Assert  
                Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_GetAddresss_MatchResult()
        {
            //Arrange  
            var controller = new AddressController(_address);

            //Act  
            var data = await controller.GetAddress();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var post = okResult.Value.Should().BeAssignableTo<List<Address>>().Subject;

            Assert.Equal(8, post[0].Id);
           

            // Assert.Equal("Test Title 2", post[1].Title);
            //  Assert.Equal("Test Description 2", post[1].Description);
        }
        [Fact]
        public async void Task_Add_InValidData_Return_Badrequest()
        {
            //Arrange  
            var controller = new AddressController(_address);
            var post = new Address()
            {

                Id=1,
                EmployeeId=1,
                Type=true,
                Line1="hyd",
                Line2= "hyd",
                City= "hyd",
                State= "ts",
                Country="india",
                Zipcode="505471",
                Active=true,
                CreatedBy=13123,
                CreatedDate=DateTime.Now,
                ModifiedBy=1432,
                ModifiedDate=DateTime.Now,
    };
            //Act  
            var data = await controller.CreateAddress(post);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new AddressController(_address);
            Address address = new Address()
            {

                Id = 1,
                EmployeeId = 1,
                Type = true,
                Line1 = "hyd",
                Line2 = "hyd",
                City = "hyd",
                State = "ts",
                Country = "india",
                Zipcode = "505471",
                Active = true,
                CreatedBy = 13123,
                CreatedDate = DateTime.Now,
                ModifiedBy = 1432,
                ModifiedDate = DateTime.Now,
            };

            //Act              
            var data = await controller.CreateAddress(address);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

    
        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            int Id = 8;

            //Act  
            var existingPost = await controller.GetAddressById(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Address>().Subject;

            var post = new Address();
            post.Id = 0;
            post.EmployeeId = result.EmployeeId;
            post.Type = result.Type;
            post.Line1 = result.Line1;
            post.Line2 = result.Line2;
            post.City = result.City;
            post.State = result.State;
            post.Country = result.Country;
            post.Zipcode = result.Zipcode;
            post.Active = result.Active;
            post.CreatedBy = result.CreatedBy;
            post.CreatedDate = System.DateTime.Now;
            post.ModifiedBy = result.ModifiedBy;
            post.ModifiedDate = System.DateTime.Now;
            var data = await controller.PutAddress(post);
            //Assert  
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_OkResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            int Id = 8;

            //Act  
            var existingPost = await controller.GetAddressById(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Address>().Subject;
            var post = new Address();
            post.Id = result.Id;
            post.EmployeeId = result.EmployeeId;
            post.Type = result.Type;
            post.Line1 = result.Line1;
            post.Line2 = result.Line2;
            post.City = result.City;
            post.State = result.State;
            post.Country = result.Country;
            post.Zipcode = result.Zipcode;
            post.Active = result.Active;
            post.CreatedBy = result.CreatedBy;
            post.CreatedDate = System.DateTime.Now;
            post.ModifiedBy = result.ModifiedBy;
            post.ModifiedDate = System.DateTime.Now;
            var data = await controller.PutAddress(post);
            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Update_Data_Return_OkResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            var Id = 8;

            //Act  
            var existingPost = await controller.GetAddressById(Id);
            var okResult = existingPost.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Address>().Subject;
            var post = new Address();
            post.Id = result.Id;
            post.EmployeeId = result.EmployeeId;
            post.Type = result.Type;
            post.Line1 = result.Line1;
            post.Line2 = result.Line2;
            post.City = result.City;
            post.State = result.State;
            post.Country = result.Country;
            post.Zipcode = result.Zipcode;
            post.Active = result.Active;
            post.CreatedBy = result.CreatedBy;
            post.CreatedDate = System.DateTime.Now;
            post.ModifiedBy = result.ModifiedBy;
            post.ModifiedDate = System.DateTime.Now;
            var data = await controller.PutAddress(post);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }
        [Fact]
        public async void Task_Delete_Post_Return_OkResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            int Id = 23;

            //Act  
            var data = await controller.DeleteAddress(Id);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_Delete_Post_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            var Id = 0;

            //Act  
            var data = await controller.DeleteAddress(Id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_Delete_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new AddressController(_address);
            int Id = 0;

            //Act  
            var data = await controller.DeleteAddress(Id);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        
        
        #region Test_Address_Line1_Fail_Case
        [Fact]
        public Task Test_Address_Line1_Fail_Case()
        {
            var address = new Address
            {
                Line1 = "",
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address) { MemberName = "Line1" };
            Validator.TryValidateProperty(address.Line1, validationContext, result);
            Assert.Equal("Please enter your Line1", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
        #region Test_Address_Line2_Fail_Case
        [Fact]
        public Task Test_Address_Line2_Fail_Case()
        {
            var address = new Address
            {
                Line2="",
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address) { MemberName = "Line2" };
            Validator.TryValidateProperty(address.Line2, validationContext, result);
            Assert.Equal("Please enter your Line2", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
        
        #region Test_Address_State_Fail_Case
        [Fact]
        public Task Test_Address_State_Fail_Case()
        {
            var address = new Address
            {
                State = "",
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address) { MemberName = "State" };
            Validator.TryValidateProperty(address.State, validationContext, result);
            Assert.Equal("Please enter your State", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
        #region Test_Address_Country_Fail_Case
        [Fact]
        public Task Test_Address_Country_Fail_Case()
        {
            var address = new Address
            {
                Country="",
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address) { MemberName = "Country" };
            Validator.TryValidateProperty(address.Country, validationContext, result);
            Assert.Equal("Please enter your Country", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
        #region Test_Address_Zipcode_Fail_Case
        [Fact]
        public Task Test_Address_Zipcode_Fail_Case()
        {
            var address = new Address
            {
                Zipcode = "",
            };
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address) { MemberName = "Zipcode" };
            Validator.TryValidateProperty(address.Zipcode, validationContext, result);
            Assert.Equal("Please enter your Zipcode", result[0].ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
        
        #region Test_Address_City_Fail_Case
        [Fact]
        public Task Test_Address_City_Fail_Case()
        {
            var address = new Address
            {
                City = ""
            };           
            var result = new List<ValidationResult>();
            var validationContext = new ValidationContext(address) { MemberName= "City" };
            var actual = Validator.TryValidateProperty(address.City, validationContext, result);
            Assert.Equal("Please enter your City", result[0].ErrorMessage);
           
            return Task.CompletedTask;
        }
        #endregion
        

    }


}
