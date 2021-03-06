using AxiaTeam1._0.Data;
using AxiaTeam1._0.Dtos;
using AxiaTeam1._0.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt;
using AxiaTeam1._0.Helpers;
using System.Security.Claims;
using Hanssens.Net;
using Microsoft.AspNetCore.SignalR;

namespace AxiaTeam1._0.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserRepository _repository ;
        private readonly JwtService _jwtService;
       
        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {

            var user = new Models.User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            if (dto.Role != null)
            {
                user.Role = dto.Role;
            }

            
            return Created("succes", _repository.Create(user));

        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);
            if (user == null)
            {
                return BadRequest(new { message = "Email introubable" });
            }
 	    else if (user.Role == null)
            {
                return BadRequest(new { message = "your account not approuved yet " });
            }
            else if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new { message ="password incorrect" });
            }
         

           

            var jwt = _jwtService.generate(user.Id);
          
            
            Response.Cookies.Append("jwt", jwt, new CookieOptions { HttpOnly = true });
           



            return Ok(new
            {
                message = "succes"
            });
        }



        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            }catch(Exception e)
            {
                return Unauthorized();
            }
           
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new { message ="succes logout" });
        }


      

        [HttpGet("users")]
        public IActionResult allUsers()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var users = _repository.getAll(userId);

                return Ok(users);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }

        }


        [HttpPut("edit/{id}")]
        public IActionResult updateUser(int id, User user)
        {
            try
            {
                if (id != user.Id)
                    return BadRequest("user ID mismatch");

                var userToUpdate =  _repository.GetById(id);

                if (userToUpdate == null)
                    return NotFound($"user with Id = {id} not found");

                return  Ok(_repository.editUser(user));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

        }

        [HttpPut("editprofile/{id}")]
        public IActionResult updateProfile(int id, User user)
        {
            try
            {
                if (id != user.Id)
                    return BadRequest("user ID mismatch");

                var userToUpdate = _repository.GetById(id);

                if (userToUpdate == null)
                    return NotFound($"user with Id = {id} not found");

                return Ok(_repository.editProfile(user));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }

        }

        [HttpPut("editpassword/{id}")]
        public IActionResult updatePassord(int id, User user)
        {
            try
            {
                if (id != user.Id)
                    return BadRequest("user ID mismatch");

                var userToUpdate = _repository.GetById(id);

                if (userToUpdate == null)
                    return NotFound($"user with Id = {id} not found");

                return Ok(_repository.editPassword(user));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }


        }



        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var userToDelete = _repository.GetById(id);

                if (userToDelete == null)
                {
                    return NotFound($"user with Id = {id} not found");
                }
                _repository.Delete(id);

                return Ok(new { message = "succes" });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }



    }
}
