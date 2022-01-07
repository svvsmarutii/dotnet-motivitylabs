using EmployeeProject.Models;
using EmployeeProject.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContact _contact;
        private readonly ILogger _logger;
        public ContactController(IContact contact)//, ILogger<ContactController> logger)
        {
            _contact = contact;
           // _logger = logger;
        }
        [HttpGet]
        [Route("Getcontact")]
        public async Task<IActionResult> Getcontact()
        {
            try
            {
                //_logger.LogInformation("contactController  Getcontact Method Started");
                var result = await _contact.GetContacts();
                if (result == null)
                    return NotFound();
                //_logger.LogInformation("contactController  Getcontact Method Ended");
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError("contact Controller Getcontact Method Log Error" + ex.Message);
            }
            return BadRequest();



        }
        [HttpGet]
        [Route("GetcontactById")]
        public async Task<IActionResult> GetcontactById(int id)
        {
            try
            {
                //_logger.LogInformation("contactController  GetcontactById Method Started");
                var result = await _contact.GetContactsById(id);
                //_logger.LogInformation("contactController  GetcontactById Method Ended");
                if (result == null)
                    return NotFound();
                else
                    return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError("contact Controller GetcontactById Method Log Error" + ex.Message);
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("Createcontact")]
        public async Task<IActionResult> Createcontact([FromBody] Contact contact)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    //_logger.LogInformation("contactController  Createcontact Method Started");
                    var Result = await _contact.CreateContact(contact);
                    //_logger.LogInformation("contactController  Createcontact Method Ended");
                    if (Result > 0)
                        return Ok(Result);
                    else
                        return NotFound();
                }
                catch (Exception ex)
                {
                    //_logger.LogError("contact Controller Createcontact Method Log Error" + ex.Message);
                }
            }
            return BadRequest();

        }
        [HttpDelete]
        [Route("Deletecontact")]
        public async Task<IActionResult> Deletecontact(int id)
        {
            try
            {
                //_logger.LogInformation("contactController  Deletecontact Method Started");
                var result = await _contact.DeleteContact(id);
                //_logger.LogInformation("contactController  Deletecontact Method Ended");
                if (result == 0)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                //_logger.LogError("contact Controller Deletecontact Method Log Error" + ex.Message);
            }
            return BadRequest();
        }
        [HttpPut]
        [Route("Putcontact")]
        public async Task<IActionResult> Putcontact([FromBody] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //_logger.LogInformation("contactController  Putcontact Method Started");
                    await _contact.PutContact(contact);
                    //_logger.LogInformation("contactController  Putcontact Method Ended");
                    return Ok();
                }
                catch (Exception ex)
                {
                    //_logger.LogError("contact Controller Putcontact Method Log Error" + ex.Message);
                }
            }
            return BadRequest();
        }


    }
}
