using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;
using WebAPI.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: MyDataController
     
        private readonly IUserService service;
        
        public UserController(IUserService service)
        {
            this.service = service;
        }


        [HttpGet("{id?}")]
        public IActionResult Get(string? id)
        {

            var myData = service.Get(id!);
            Debug.WriteLine(myData);

            if (myData == null)
            {
                return NotFound($"User with ID = {id} not found");
            }
          
         
            return Ok(myData);
           
        }



        /*[HttpPost()]
        public ActionResult<User> Post([FromBody] User user)
        {
           User newUser = service.Create(user);
            return Ok(newUser);
           
        }*/

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] Login user)
        {

            try
            {
                User newLogn = await  service.Login(user);
                Console.Write(newLogn);
                return Ok(newLogn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
            
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> createUser(User user) //pass the id
        {
            try
            {
                User newUserData = await service.createUser(user); //
                Console.Write(newUserData);
                return Ok(newUserData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

    }
