using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sixshop.Controllers
{
    [ApiController]
    [Route(template:"api/v1/users")]
    public class UserController : ControllerBase
    {
        public static List<User> Users = new();
        public sealed class UserRegisterRequest
        { 
            [Required(ErrorMessage = "Имя пользователя - обязательно")]
            public string Name { get; set; }
            [MaxLength(30)]
            [MinLength(6)]
            public string Password { get; set; }
        }

        [HttpPost]
        public IActionResult Register(UserRegisterRequest request)
        {
            var newUser = new User
            {
                Id = Users.Count + 1,
                Name = request.Name,
                Password = request.Password
            };
            Users.Add(newUser);

            return Created($"api/v1/users/{newUser.Id}", newUser.ToDto());

        }

        [HttpGet(template:"{id}")]
        public UserDto Get(int id)
        {
            return Users.FirstOrDefault(user => user.Id == id)?.ToDto();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = Users.FirstOrDefault(user => user.Id == id);

            if (user == null)
            {
                return NotFound("Пользователя не существует");
            }

            Users.Remove(user);

            return NoContent();
        }

        public class User 
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
        }

        public class UserDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
