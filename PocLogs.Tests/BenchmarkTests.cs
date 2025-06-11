using BenchmarkDotNet.Running;

namespace PocLogs.Tests;

public class BenchmarkTests
{
    [Fact]
    public void CpfValidationBenchmark_ShouldHaveMeanBelowOneSecond()
    {
        var summary = BenchmarkRunner.Run<CpfValidationBenchmark>();
        foreach (var report in summary.Reports)
        {
            Assert.NotNull(report.ResultStatistics);
            var meanNanoseconds = report.ResultStatistics!.Mean;
            double meanSeconds = meanNanoseconds / 1_000_000_000.0;
            Assert.True(meanSeconds < 1, $"Benchmark {report.BenchmarkCase.DisplayInfo} took {meanSeconds} seconds on average");
        }
    }
}
