# Benchmark

O projeto `PocLogs.Benchmarks` mede o desempenho da validação de CPF com o BenchmarkDotNet. Os testes automatizados falham caso a média ultrapasse um segundo.

Para executar manualmente:

```bash
dotnet run --project PocLogs.Benchmarks -c Release
```
