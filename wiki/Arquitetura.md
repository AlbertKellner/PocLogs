# Arquitetura

O projeto é composto por três camadas principais:

1. **PocLogs.Api** – aplicação ASP.NET Core que expõe os endpoints.
2. **PocLogs.Tests** – testes automatizados e benchmarks.
3. **PocLogs.Benchmarks** – projeto auxiliar para o BenchmarkDotNet.

A API define três controllers:

- `SumController`
- `CpfILoggerController`
- `CpfSerilogController`

O middleware `CorrelationIdMiddleware` injeta o cabeçalho `X-Correlation-Id` em todas as respostas, facilitando o rastreamento dos logs.
