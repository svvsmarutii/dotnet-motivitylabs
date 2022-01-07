using EmployeeProject.Authentication;
using EmployeeProject.Models;
using EmployeeProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddress _address;
       // private readonly ILogger _logger;
        public AddressController(IAddress address)//, ILogger<AddressController> logger)
        {
            _address = address;
            //_logger = logger;
        }
        [HttpGet]
        [Route("GetAddress")]
        public async Task<IActionResult> GetAddress()
        {
            try
            {
                //_logger.LogInformation("AddressController  GetAddress Method Started");
                var result = await _address.GetAddresss();
                if (result == null)
                    return NotFound();
                //_logger.LogInformation("AddressController  GetAddress Method Ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Address Controller GetAddress Method Log Error" + ex.Message);
            }
            return BadRequest();



        }
        [HttpGet]
        [Route("GetAddressById")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            try
            {
                //_logger.LogInformation("AddressController  GetAddressById Method Started");
                var result = await _address.GetAddresssById(id);
                //_logger.LogInformation("AddressController  GetAddressById Method Ended");
                if (result == null)
                    return NotFound();
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Address Controller GetAddressById Method Log Error" + ex.Message);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("CreateAddress")]
        public async Task<IActionResult> CreateAddress([FromBody] Address address)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    //_logger.LogInformation("AddressController  CreateAddress Method Started");
                    var Result = await _address.CreateAdress(address);
                    //_logger.LogInformation("AddressController  CreateAddress Method Ended");
                    if (Result > 0)
                        return Ok(Result);
                    else
                        return NotFound();
                }
                catch (Exception ex)
                {
                    //_logger.LogError("Address Controller CreateAddress Method Log Error" + ex.Message);
                }
            }
            return BadRequest();

        }
        [HttpDelete]
        [Route("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            try
            {
                //_logger.LogInformation("AddressController  DeleteAddress Method Started");
                var result = await _address.DeleteAddress(id);
                //_logger.LogInformation("AddressController  DeleteAddress Method Ended");
                if (result == 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Address Controller DeleteAddress Method Log Error" + ex.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("PutAddress")]
        public async Task<IActionResult> PutAddress([FromBody] Address address)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //_logger.LogInformation("AddressController  PutAddress Method Started");
                    await _address.PutAddress(address);
                    //_logger.LogInformation("AddressController  PutAddress Method Ended");
                    return Ok();
                }
                catch (Exception ex)
                {
                    //_logger.LogError("Address Controller PutAddress Method Log Error" + ex.Message);
                }
            }
            return BadRequest();
        }


    }
}
