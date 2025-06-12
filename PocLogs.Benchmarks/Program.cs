using System.Diagnostics.CodeAnalysis;
using BenchmarkDotNet.Running;

[assembly: ExcludeFromCodeCoverage]

BenchmarkRunner.Run<CpfValidationBenchmark>();
