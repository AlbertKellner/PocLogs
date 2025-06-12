using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;

namespace PocLogs.Api.Validators;
[ExcludeFromCodeCoverage]

internal static partial class CpfValidatorLogMessages
{
    [LoggerMessage(EventId = 0, Level = LogLevel.Information, Message = "Starting validation for {Cpf}")]
    public static partial void StartingValidation(ILogger logger, string cpf);

    [LoggerMessage(EventId = 1, Level = LogLevel.Information, Message = "CPF is empty or whitespace")]
    public static partial void CpfNullOrEmpty(ILogger logger);

    [LoggerMessage(EventId = 2, Level = LogLevel.Information, Message = "Digits only: {Cpf}")]
    public static partial void DigitsOnly(ILogger logger, string cpf);

    [LoggerMessage(EventId = 3, Level = LogLevel.Information, Message = "Invalid length")]
    public static partial void InvalidLength(ILogger logger);

    [LoggerMessage(EventId = 4, Level = LogLevel.Information, Message = "All digits equal")]
    public static partial void AllDigitsEqual(ILogger logger);

    [LoggerMessage(EventId = 5, Level = LogLevel.Information, Message = "First digit calculated: {Digit}")]
    public static partial void FirstDigitCalculated(ILogger logger, int digit);

    [LoggerMessage(EventId = 6, Level = LogLevel.Information, Message = "First digit mismatch")]
    public static partial void FirstDigitMismatch(ILogger logger);

    [LoggerMessage(EventId = 7, Level = LogLevel.Information, Message = "Second digit calculated: {Digit}")]
    public static partial void SecondDigitCalculated(ILogger logger, int digit);

    [LoggerMessage(EventId = 8, Level = LogLevel.Information, Message = "Second digit mismatch")]
    public static partial void SecondDigitMismatch(ILogger logger);

    [LoggerMessage(EventId = 9, Level = LogLevel.Information, Message = "CPF is valid")]
    public static partial void CpfValid(ILogger logger);
}
