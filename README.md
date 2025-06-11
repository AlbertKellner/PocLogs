# PocLogs

Este repositório contém um exemplo simples de microserviço em .NET 8 que demonstra validação de CPF e uso de logs.

## Projetos

- **PocLogs.Api** – aplicação ASP.NET Core com três controllers.
- **PocLogs.Tests** – testes xUnit e benchmarks.
- **PocLogs.Benchmarks** – projeto auxiliar para o BenchmarkDotNet.

## Controllers

- **SumController** – `POST /Sum` soma `1` ao valor enviado.
- **CpfILoggerController** – `POST /CpfILogger` valida um CPF usando `ILogger`.
- **CpfSerilogController** – `POST /CpfSerilog` valida um CPF usando Serilog.

O middleware `CorrelationIdMiddleware` adiciona o cabeçalho `X-Correlation-Id` 
a todas as respostas.

## Execução

Inicie a API com:

```bash
dotnet run --project PocLogs.Api
```

A documentação Swagger ficará disponível em `https://localhost:7038/swagger` (ou porta configurada).

## Testes e benchmark

Os testes em `PocLogs.Tests` cobrem os controllers e um benchmark que assegura 
que a validação de CPF leva menos de um segundo em média.

## Documentação

Além deste README, consulte os arquivos `controllers.md`, `cpf_converter.md` e `tests.md` na raiz do repositório para detalhes das rotas, validação de CPF e testes.
