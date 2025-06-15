using Microsoft.Extensions.Logging;
using PocLogs.Api.Validators;

namespace PocLogs.Tests;

public class LogMessagesTests
{
    private class FakeLogger : ILogger
    {
        private readonly bool _enabled;
        public FakeLogger(bool enabled) => _enabled = enabled;

        public IDisposable BeginScope<TState>(TState state) => NullScope.Instance;
        public bool IsEnabled(LogLevel logLevel) => _enabled;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) {}

        private class NullScope : IDisposable { public static readonly NullScope Instance = new(); public void Dispose() {} }
    }

    [Fact]
    public void AllMessages_CoverBothBranches()
    {
        var enabledLogger = new FakeLogger(true);
        var disabledLogger = new FakeLogger(false);

        CpfValidatorLogMessages.StartingValidation(enabledLogger, "123");
        CpfValidatorLogMessages.StartingValidation(disabledLogger, "123");
        CpfValidatorLogMessages.CpfNullOrEmpty(enabledLogger);
        CpfValidatorLogMessages.CpfNullOrEmpty(disabledLogger);
        CpfValidatorLogMessages.DigitsOnly(enabledLogger, "123");
        CpfValidatorLogMessages.DigitsOnly(disabledLogger, "123");
        CpfValidatorLogMessages.InvalidLength(enabledLogger);
        CpfValidatorLogMessages.InvalidLength(disabledLogger);
        CpfValidatorLogMessages.AllDigitsEqual(enabledLogger);
        CpfValidatorLogMessages.AllDigitsEqual(disabledLogger);
        CpfValidatorLogMessages.FirstDigitCalculated(enabledLogger, 1);
        CpfValidatorLogMessages.FirstDigitCalculated(disabledLogger, 1);
        CpfValidatorLogMessages.FirstDigitMismatch(enabledLogger);
        CpfValidatorLogMessages.FirstDigitMismatch(disabledLogger);
        CpfValidatorLogMessages.SecondDigitCalculated(enabledLogger, 1);
        CpfValidatorLogMessages.SecondDigitCalculated(disabledLogger, 1);
        CpfValidatorLogMessages.SecondDigitMismatch(enabledLogger);
        CpfValidatorLogMessages.SecondDigitMismatch(disabledLogger);
        CpfValidatorLogMessages.CpfValid(enabledLogger);
        CpfValidatorLogMessages.CpfValid(disabledLogger);
    }
}
