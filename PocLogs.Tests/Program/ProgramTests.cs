using System.Reflection;

namespace PocLogs.Tests.Program;

public class ProgramTests
{
    [Fact]
    public void EntryPoint_ExecutesWithoutErrors()
    {
        var entry = typeof(global::Program).Assembly.EntryPoint!;
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        entry.Invoke(null, new object?[] { Array.Empty<string>() });
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", null);
    }
}

public class BenchmarksProgramTests
{
    [Fact]
    public void EntryPoint_ExecutesBenchmarkProgram()
    {
        var entry = typeof(CpfValidationBenchmark).Assembly.EntryPoint!;
        entry.Invoke(null, new object?[] { Array.Empty<string>() });
    }
}
