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
        if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
        {
            _logger.Information("Starting validation for {Cpf}", cpf);
        }
        if (string.IsNullOrWhiteSpace(cpf))
        {
            if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
                _logger.Information("CPF is null or empty");
            return false;
        }

        Span<char> digits = cpf.Length <= 32 ? stackalloc char[cpf.Length] : new char[cpf.Length];
        int idx = 0;
        foreach (var ch in cpf)
        {
            if (char.IsDigit(ch))
                digits[idx++] = ch;
        }
        cpf = new string(digits.Slice(0, idx));
        if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
            _logger.Information("Digits only: {Cpf}", cpf);
        if (cpf.Length != 11)
        {
            if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
                _logger.Information("Invalid length");
            return false;
        }

        bool allEqual = true;
        for (int i = 1; i < cpf.Length; i++)
        {
            if (cpf[i] != cpf[0])
            {
                allEqual = false;
                break;
            }
        }
        if (allEqual)
        {
            if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
                _logger.Information("All digits equal");
            return false;
        }

        int[] numbers = new int[11];
        for (int i = 0; i < 11; i++)
            numbers[i] = cpf[i] - '0';

        int sum = 0;
        for (int i = 0; i < 9; i++)
            sum += numbers[i] * (10 - i);
        int result = sum % 11;
        int firstDigit = result < 2 ? 0 : 11 - result;
        if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
            _logger.Information("First digit calculated: {Digit}", firstDigit);
        if (numbers[9] != firstDigit)
        {
            if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
                _logger.Information("First digit mismatch");
            return false;
        }

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += numbers[i] * (11 - i);
        result = sum % 11;
        int secondDigit = result < 2 ? 0 : 11 - result;
        if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
            _logger.Information("Second digit calculated: {Digit}", secondDigit);
        if (numbers[10] != secondDigit)
        {
            if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
                _logger.Information("Second digit mismatch");
            return false;
        }

        if (_logger.IsEnabled(Serilog.Events.LogEventLevel.Information))
            _logger.Information("CPF is valid");
        return true;
    }
}
