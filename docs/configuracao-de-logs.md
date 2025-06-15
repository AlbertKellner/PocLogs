# Configuração de Logs

O projeto utiliza Serilog como provedor principal. As configurações ficam em `appsettings.json` e são lidas durante a criação do host. Os logs são enviados de forma assíncrona para o console.

Além do Serilog, o `ILogger` padrão do ASP.NET Core pode ser usado por meio do `CpfValidatorWithILogger`. Ambos os validadores produzem as mesmas mensagens definidas em `CpfValidatorLogMessages`.

O middleware `CorrelationIdMiddleware` garante que cada requisição possua um identificador único para facilitar a correlação dos logs.
