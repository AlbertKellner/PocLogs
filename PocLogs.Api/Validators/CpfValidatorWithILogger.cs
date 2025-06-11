using Microsoft.Extensions.Logging;

namespace PocLogs.Api.Validators;

public class CpfValidatorWithILogger
{
    private readonly ILogger<CpfValidatorWithILogger> _logger;

    public CpfValidatorWithILogger(ILogger<CpfValidatorWithILogger> logger)
    {
        _logger = logger;
    }

    public bool IsValid(string? cpf)
    {
        _logger.LogInformation("Starting validation for {Cpf}", cpf);
        if (string.IsNullOrWhiteSpace(cpf))
        {
            _logger.LogInformation("CPF is null or empty");
            return false;
        }

        cpf = new string(cpf.Where(char.IsDigit).ToArray());
        _logger.LogInformation("Digits only: {Cpf}", cpf);
        if (cpf.Length != 11)
        {
            _logger.LogInformation("Invalid length");
            return false;
        }

        if (cpf.Distinct().Count() == 1)
        {
            _logger.LogInformation("All digits equal");
            return false;
        }

        int[] numbers = cpf.Select(c => c - '0').ToArray();

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += numbers[i] * (10 - i);
        int result = sum % 11;
        int firstDigit = result < 2 ? 0 : 11 - result;
        _logger.LogInformation("First digit calculated: {Digit}", firstDigit);
        if (numbers[9] != firstDigit)
        {
            _logger.LogInformation("First digit mismatch");
            return false;
        }

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += numbers[i] * (11 - i);
        result = sum % 11;
        int secondDigit = result < 2 ? 0 : 11 - result;
        _logger.LogInformation("Second digit calculated: {Digit}", secondDigit);
        if (numbers[10] != secondDigit)
        {
            _logger.LogInformation("Second digit mismatch");
            return false;
        }

        _logger.LogInformation("CPF is valid");
        return true;
    }
}
