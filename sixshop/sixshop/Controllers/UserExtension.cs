using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi.Core.DTO;

namespace sixshop.Controllers
{
    public static class UserExtension
    {
        public static UserController.UserDto ToDto(this UserController.User user)
        {
            return new UserController.UserDto
            {
                Id = user.Id,
                Name = user.Name
            };
        }

    }
}
