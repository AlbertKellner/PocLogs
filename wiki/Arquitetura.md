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

## Injeção de Dependência e Middleware

Os validadores de CPF são registrados como serviços `Scoped` no `Program.cs` e o Serilog é configurado como provedor de logs padrão. O middleware `CorrelationIdMiddleware` é adicionado ao pipeline para garantir um identificador de correlação em cada requisição.

```csharp
builder.Services.AddScoped<CpfValidatorWithILogger>();
builder.Services.AddScoped<CpfValidatorWithSerilog>();
app.UseMiddleware<CorrelationIdMiddleware>();
```

## Frameworks

Além do ASP.NET Core, o projeto utiliza Serilog para logs, xUnit e BenchmarkDotNet para testes e medições de desempenho, e o Swashbuckle para geração do Swagger.

Detalhes de infraestrutura e organização de pastas podem ser vistos em [Infraestrutura](Infraestrutura).
