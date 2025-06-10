using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace PocLogs.Api.Controllers;

public record CpfRequest(string Cpf);

[ApiController]
[Route("[controller]")]
public class CpfController : ControllerBase
{
    [HttpPost("validate")]
    public ActionResult<bool> Validate([FromBody] CpfRequest request)
    {
        var isValid = CpfValidator.IsValid(request.Cpf);
        return Ok(isValid);
    }
}

internal static class CpfValidator
{
    public static bool IsValid(string? cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        var digitsOnly = new string(cpf.Where(char.IsDigit).ToArray());
        if (digitsOnly.Length != 11)
            return false;
        if (digitsOnly.Distinct().Count() == 1)
            return false;

        int[] numbers = digitsOnly.Select(c => c - '0').ToArray();

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += numbers[i] * (10 - i);
        int remainder = sum % 11;
        int firstCheck = remainder < 2 ? 0 : 11 - remainder;
        if (numbers[9] != firstCheck)
            return false;

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += numbers[i] * (11 - i);
        remainder = sum % 11;
        int secondCheck = remainder < 2 ? 0 : 11 - remainder;
        return numbers[10] == secondCheck;
    }
}
