using PocLogs.Api.Validators;
using Serilog;

namespace PocLogs.Tests;

public class CpfValidatorWithSerilogTests
{
    private readonly CpfValidatorWithSerilog _validator = new(new LoggerConfiguration().CreateLogger());

    [Theory]
    [InlineData("52998224725")]
    [InlineData("12345678909")]
    public void IsValid_ReturnsTrue_ForValidCpf(string cpf)
    {
        Assert.True(_validator.IsValid(cpf));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void IsValid_ReturnsFalse_ForNullOrWhitespace(string? cpf)
    {
        Assert.False(_validator.IsValid(cpf!));
    }

    [Fact]
    public void IsValid_ReturnsFalse_ForInvalidLength()
    {
        Assert.False(_validator.IsValid("1234567890"));
    }

    [Fact]
    public void IsValid_ReturnsFalse_WhenAllDigitsEqual()
    {
        Assert.False(_validator.IsValid("11111111111"));
    }

    [Fact]
    public void IsValid_ReturnsFalse_WhenFirstDigitMismatch()
    {
        Assert.False(_validator.IsValid("52998224715"));
    }

    [Fact]
    public void IsValid_ReturnsFalse_WhenSecondDigitMismatch()
    {
        Assert.False(_validator.IsValid("52998224724"));
    }
}
