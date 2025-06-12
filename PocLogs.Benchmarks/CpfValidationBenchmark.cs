using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging.Abstractions;
using PocLogs.Api.Validators;
using Serilog;
using Serilog.Core;
using Serilog.Events;

[ExcludeFromCodeCoverage]
public class CpfValidationBenchmark
{
    private readonly CpfValidatorWithILogger _iLoggerValidator;
    private readonly CpfValidatorWithSerilog _serilogValidator;
    private const string ValidCpf = "52998224725";

    public CpfValidationBenchmark()
    {
        _iLoggerValidator = new CpfValidatorWithILogger(new NullLogger<CpfValidatorWithILogger>());
        var logger = new LoggerConfiguration().WriteTo.Sink(new NullSink()).CreateLogger();
        _serilogValidator = new CpfValidatorWithSerilog(logger);
    }

    [Benchmark]
    public bool ValidateWithILogger() => _iLoggerValidator.IsValid(ValidCpf);

    [Benchmark]
    public bool ValidateWithSerilog() => _serilogValidator.IsValid(ValidCpf);

    private class NullSink : ILogEventSink
    {
        public void Emit(LogEvent logEvent) { }
    }
}
