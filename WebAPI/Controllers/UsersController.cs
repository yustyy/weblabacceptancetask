using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {

        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        //[HttpPost("add")]
        //public ActionResult Add(User user)
        //{
           // var result =  _userService.Add(user);
           //
            //if (result.Success)
            //{
              //  return Ok(result);
            //}
            //
            //return BadRequest(result);
        //}

        [HttpGet("getbyid")]
        public ActionResult GetById(int id)
        {
            var result = _userService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public ActionResult GetAll()
        {
            var result = _userService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}

