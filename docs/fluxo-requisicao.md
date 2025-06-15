# Fluxo de Requisição

1. A chamada chega ao controller correspondente.
2. O controller invoca o validador de CPF ou a lógica necessária.
3. Mensagens de log são registradas conforme a validação avança.
4. O `CorrelationIdMiddleware` injeta o cabeçalho `X-Correlation-Id` na resposta.
5. O resultado é devolvido ao cliente.

Esse fluxo é o mesmo para todos os endpoints e pode ser visualizado via Swagger durante a execução.
