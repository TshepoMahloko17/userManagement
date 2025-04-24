using Microsoft.AspNetCore.Mvc;
using System.Net;
using userManagement.DatabaseContext;
using userManagement.Dtos;
using userManagement.Entities;

namespace userManagement.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        [Route("GetUsers")]
        [HttpGet]
        public List<UserDto> Get()
        {
            var context = new UserManagementDBContext();

            return context.Users.Select(c => new UserDto
            {
                Name = c.Name,
                Email = c.Email
            }).ToList();
        }

        [Route("AddNewUsers")]
        [HttpPost]
        public HttpStatusCode Post([FromBody] AddUserDto user)
        {
            var context = new UserManagementDBContext();

            var userOb = new Users
            {
                Name = user.Name,
                Email = user.Email,
            };

            context.Users.Add(userOb);
            context.SaveChanges();
            return HttpStatusCode.OK;
        }

        [Route("UpdateUsers")]
        [HttpPut]
        public HttpStatusCode Put(UpdateUserDto user)
        {
            var context = new UserManagementDBContext();

            var userObj = new Users
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };

            context.Users.Update(userObj);
            context.SaveChanges();
            return HttpStatusCode.OK;
        }

        [Route("DeleteUsers")]
        [HttpDelete]
        public HttpStatusCode Delete(int userId)
        {
            var context = new UserManagementDBContext();

            var userObj = context.Users.First(c => c.Id == userId);

            context.Users.Remove(userObj);
            context.SaveChanges();
            return HttpStatusCode.OK;
        }
    }
}
