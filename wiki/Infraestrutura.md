# Infraestrutura e Estrutura de Pastas

Esta seção descreve o ambiente e a organização do projeto.

## Frameworks Utilizados

- **.NET 8** – plataforma principal para a API e testes.
- **ASP.NET Core** – base para a aplicação web.
- **Serilog** – biblioteca de logs assíncronos exibidos no console.
- **xUnit** – framework de testes unitários.
- **BenchmarkDotNet** – executa medições de desempenho.
- **Swashbuckle** – gera a documentação Swagger.

## Injeção de Dependência

Os serviços são registrados no `Program.cs` com o contêiner padrão do ASP.NET Core:

```csharp
builder.Services.AddControllers();
builder.Services.AddScoped<CpfValidatorWithILogger>();
builder.Services.AddScoped<CpfValidatorWithSerilog>();
```

O Serilog é configurado durante a criação do host e o middleware `CorrelationIdMiddleware` é adicionado ao pipeline.

## Estrutura de Pastas

- **PocLogs.Api** – controllers, middlewares, validadores e modelos da API.
- **PocLogs.Tests** – testes automatizados e benchmarks.
- **PocLogs.Benchmarks** – projeto auxiliar usado pelos benchmarks.
- **wiki** – documentação que é publicada automaticamente na Wiki do GitHub.

## Regras de Negócio

A principal regra implementada é a [validação de CPF](ValidacaoCpf), utilizada pelos controllers de CPF. Cada requisição executa múltiplas validações para gerar logs e medir desempenho.
