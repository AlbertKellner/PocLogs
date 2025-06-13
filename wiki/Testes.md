# Testes

Os testes estão no projeto `PocLogs.Tests` e utilizam xUnit.

## SumControllerTests

Garante que o endpoint `/Sum` retorna `Id + 1`.

## CpfControllerTests

Verifica o comportamento das controllers de CPF:

- `CpfILoggerController` deve retornar `true` para um CPF válido.
- `CpfSerilogController` deve retornar `false` para um CPF inválido.

## BenchmarkTests

Executa `CpfValidationBenchmark` e falha caso o tempo médio ultrapasse um segundo.

Execute todos os testes com:

```bash
dotnet test
```
