using Microsoft.Extensions.Logging;
namespace PocLogs.Api.Validators;

public class CpfValidatorWithILogger
{
    private readonly ILogger<CpfValidatorWithILogger> _logger;

    public CpfValidatorWithILogger(ILogger<CpfValidatorWithILogger> logger)
    {
        _logger = logger;
    }

    public bool IsValid(string cpf)
    {
        CpfValidatorLogMessages.StartingValidation(_logger, cpf);
        if (string.IsNullOrWhiteSpace(cpf))
        {
            CpfValidatorLogMessages.CpfNullOrEmpty(_logger);
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
        CpfValidatorLogMessages.DigitsOnly(_logger, cpf);
        if (cpf.Length != 11)
        {
            CpfValidatorLogMessages.InvalidLength(_logger);
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
            CpfValidatorLogMessages.AllDigitsEqual(_logger);
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
        CpfValidatorLogMessages.FirstDigitCalculated(_logger, firstDigit);
        if (numbers[9] != firstDigit)
        {
            CpfValidatorLogMessages.FirstDigitMismatch(_logger);
            return false;
        }

        sum = 0;
        for (int i = 0; i < 10; i++)
            sum += numbers[i] * (11 - i);
        result = sum % 11;
        int secondDigit = result < 2 ? 0 : 11 - result;
        CpfValidatorLogMessages.SecondDigitCalculated(_logger, secondDigit);
        if (numbers[10] != secondDigit)
        {
            CpfValidatorLogMessages.SecondDigitMismatch(_logger);
            return false;
        }

        CpfValidatorLogMessages.CpfValid(_logger);
        return true;
    }
}
