using Infrastructure.Persistence.Entities;
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
        var user = new ApplicationUser
        {
            Id = "1",
            Email = "old@mail.com",
            UserName = "old@mail.com",
            FirstName = "Old",
            LastName = "Name"
        };

        var userManagerMock = MockUserManager(user);

        var signInManagerMock = new Mock<SignInManager<ApplicationUser>>(
            userManagerMock.Object,
            Mock.Of<IHttpContextAccessor>(),
            Mock.Of<IUserClaimsPrincipalFactory<ApplicationUser>>(),
            null, null, null, null);

        var controller = new MyAccountController(userManagerMock.Object, signInManagerMock.Object);

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
            FirstName = "New",
            LastName = "Person",
            Email = "new@mail.com",
            PhoneNumber = "123456"
        };

        // Act
        var result = await controller.Index(model);

        // Assert
        Assert.Equal("new@mail.com", user.Email);
        Assert.Equal("new@mail.com", user.UserName);
        Assert.Equal("123456", user.PhoneNumber);
        Assert.Equal("New", user.FirstName);
        Assert.Equal("Person", user.LastName);
    }

    private Mock<UserManager<ApplicationUser>> MockUserManager(ApplicationUser user)
    {
        var store = new Mock<IUserStore<ApplicationUser>>();

        var mgr = new Mock<UserManager<ApplicationUser>>(
            store.Object, null, null, null, null, null, null, null, null);

        mgr.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
            .ReturnsAsync(user);

        mgr.Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>()))
            .ReturnsAsync(IdentityResult.Success);

        return mgr;
    }
}