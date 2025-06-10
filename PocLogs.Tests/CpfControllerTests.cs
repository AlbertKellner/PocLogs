using PocLogs.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PocLogs.Tests;

public class CpfControllerTests
{
    [Fact]
    public void Validate_ReturnsTrue_ForValidCpf()
    {
        var controller = new CpfController();
        var result = controller.Validate(new CpfRequest("52998224725"));

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.True((bool)okResult.Value!);
    }

    [Fact]
    public void Validate_ReturnsFalse_ForInvalidCpf()
    {
        var controller = new CpfController();
        var result = controller.Validate(new CpfRequest("12345678900"));

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.False((bool)okResult.Value!);
    }
}
