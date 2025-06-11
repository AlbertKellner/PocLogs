using Serilog;

namespace PocLogs.Api.Validators;

public class CpfValidatorWithSerilog
{
    private readonly Serilog.ILogger _logger;

    public CpfValidatorWithSerilog(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    public bool IsValid(string? cpf)
    {
        _logger.Information("Starting validation for {Cpf}", cpf);
        if (string.IsNullOrWhiteSpace(cpf))
        {
            _logger.Information("CPF is null or empty");
            return false;
        }

        cpf = new string(cpf.Where(char.IsDigit).ToArray());
        _logger.Information("Digits only: {Cpf}", cpf);
        if (cpf.Length != 11)
        {
            _logger.Information("Invalid length");
            return false;
        }

        if (cpf.Distinct().Count() == 1)
        {
            _logger.Information("All digits equal");
            return false;
        }

        int[] numbers = cpf.Select(c => c - '0').ToArray();

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += numbers[i] * (10 - i);
        int result = sum % 11;
        int firstDigit = result < 2 ? 0 : 11 - result;
        _logger.Information("First digit calculated: {Digit}", firstDigit);
        if (numbers[9] != firstDigit)
        {
            _logger.Information("First digit mismatch");
            return false;
        }

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += numbers[i] * (11 - i);
        result = sum % 11;
        int secondDigit = result < 2 ? 0 : 11 - result;
        _logger.Information("Second digit calculated: {Digit}", secondDigit);
        if (numbers[10] != secondDigit)
        {
            _logger.Information("Second digit mismatch");
            return false;
        }

        _logger.Information("CPF is valid");
        return true;
    }
}
