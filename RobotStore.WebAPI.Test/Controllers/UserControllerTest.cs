using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

using RobotStore.WebAPI.Controllers;
using RobotStore.WebAPI.Models;
using Microsoft.AspNetCore.Http;

namespace RobotStore.WebAPI.Test.Controllers
{
    public class UserControllerTest
    {
        private readonly FakeUserManager userManager;
        private readonly FakeSignInManager signInManager;
        private readonly ApplicationSettings appSettings;
        private readonly IOptions<ApplicationSettings> options;
        private readonly Mock<IUserStore<User>> mockStore;
        public UserControllerTest()
        {
            mockStore = new Mock<IUserStore<User>>();
            userManager = new FakeUserManager();
            signInManager = new FakeSignInManager();
            appSettings = new ApplicationSettings() { JWT_Secret = "2301202024012020" };
            options = Options.Create<ApplicationSettings>(appSettings);
        }

        [Fact]
        public async Task CanPostUser()
        {
            var model = new UserModel() { UserName = "test", FullName = "test", Password = "test"};
            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                IsAdmin = false
            };

            var userController = new UserController(userManager, signInManager, options);
            var result = await userController.PostApplicationUser(model);
            
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal(IdentityResult.Success, okResult.Value);
        }
        
        [Fact]
        public async Task CanAthenticateUser()
        {
            var user = new 
            {
                UserName = "test",
                Email = "",
                FullName = "",
                IsAdmin = false
            };


            var userController = new UserController(userManager, signInManager, options);
            var result = await userController.Login(new LoginModel() { Login = "test", Password = "test" });
            
           
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Contains(user.ToString(), okResult.Value.ToString());
        }
    }

    public class JsonResult
    {
        public string token { get; set; }
        public User User { get; set; }
    };
}

