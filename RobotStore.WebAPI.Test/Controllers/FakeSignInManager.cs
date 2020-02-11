using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using RobotStore.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;

namespace RobotStore.WebAPI.Test.Controllers
{
    public class FakeSignInManager : SignInManager<User>
    {
        public FakeSignInManager()
                : base(new FakeUserManager(),
                     new Mock<IHttpContextAccessor>().Object,
                     new Mock<IUserClaimsPrincipalFactory<User>>().Object,
                     new Mock<IOptions<IdentityOptions>>().Object,
                     new Mock<ILogger<SignInManager<User>>>().Object,
                     new Mock<IAuthenticationSchemeProvider>().Object,
                     new Mock<IUserConfirmation<User>>().Object)
        { }
    }
}
