using PocLogs.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace PocLogs.Tests;

public class SumControllerTests
{
    [Fact]
    public void Post_ReturnsIdPlusOne()
    {
        var controller = new SumController();
        var result = controller.Post(new IdRequest(41));

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Equal(42L, okResult.Value);
    }
}
