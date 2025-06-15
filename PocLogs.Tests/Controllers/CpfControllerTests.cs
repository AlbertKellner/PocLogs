using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using PocLogs.Api.Controllers;
using PocLogs.Api.Models;
using PocLogs.Api.Validators;
using Serilog;

namespace PocLogs.Tests;

public class CpfControllerTests
{
    [Fact]
    public void ILoggerController_ReturnsTrueForValidCpf()
    {
        var validator = new CpfValidatorWithILogger(new NullLogger<CpfValidatorWithILogger>());
        var controller = new CpfILoggerController(validator);

        var result = controller.Post(new CpfRequest("52998224725"));
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.True((bool)okResult.Value!);
    }

    [Fact]
    public void SerilogController_ReturnsFalseForInvalidCpf()
    {
        var validator = new CpfValidatorWithSerilog(new LoggerConfiguration().CreateLogger());
        var controller = new CpfSerilogController(validator);

        var result = controller.Post(new CpfRequest("12345678900"));
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.False((bool)okResult.Value!);
    }
}
