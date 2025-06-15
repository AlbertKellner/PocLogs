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

## Cobertura

A action **Cobertura por Arquivo** executa os testes e gera um relatório de
cobertura em Markdown. O resumo é exibido diretamente no workflow do GitHub.

## Documentação Completa

Todo o material detalhado sobre arquitetura, rotas, validação de CPF e execução do projeto está disponível na [Wiki](https://github.com/AlbertKellner/PocLogs/wiki). Consulte a Wiki para mais informações.
As páginas localizadas no diretório `wiki/` são publicadas automaticamente na Wiki do GitHub por meio de um workflow de integração contínua.

## Documentação Complementar

Arquivos adicionais encontram-se na pasta [docs](docs/), incluindo exemplos de uso e detalhes sobre a configuração de logs.

Para contribuir, leia o [CONTRIBUTING.md](CONTRIBUTING.md).
