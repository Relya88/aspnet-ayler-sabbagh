using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Presentation.WebApp.Controllers;
using Presentation.WebApp.Models;
using System.Security.Claims;
using Xunit;

public class MyAccountTests
{
    [Fact]
    public async Task Index_Post_ValidModel_UpdatesUser()
    {
        // Arrange
        var user = new IdentityUser
        {
            Id = "1",
            Email = "old@mail.com",
            UserName = "old@mail.com"
        };

        var userManagerMock = MockUserManager(user);

        var signInManagerMock = new Mock<SignInManager<IdentityUser>>(
        userManagerMock.Object,
        Mock.Of<Microsoft.AspNetCore.Http.IHttpContextAccessor>(),
        Mock.Of<IUserClaimsPrincipalFactory<IdentityUser>>(),
        null, null, null, null);

        var controller = new MyAccountController(userManagerMock.Object, signInManagerMock.Object);

        // fake logged-in user
        var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, "1")
        }, "mock"));

        controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = userPrincipal }
        };

        var model = new MyAccountViewModel
        {
            Id = "1",
            Email = "new@mail.com",
            PhoneNumber = "123456"
        };

        // Act
        var result = await controller.Index(model);

        // Assert
        Assert.Equal("new@mail.com", user.Email);
    }

    private Mock<UserManager<IdentityUser>> MockUserManager(IdentityUser user)
    {
        var store = new Mock<IUserStore<IdentityUser>>();
        var mgr = new Mock<UserManager<IdentityUser>>(
            store.Object, null, null, null, null, null, null, null, null);

        mgr.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
            .ReturnsAsync(user);

        mgr.Setup(x => x.UpdateAsync(It.IsAny<IdentityUser>()))
            .ReturnsAsync(IdentityResult.Success);

        return mgr;
    }
}