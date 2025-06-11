# Controllers

Este documento descreve as rotas expostas por `PocLogs.Api` e como testá-las usando `curl`.

## SumController

Soma `1` ao valor fornecido.

- **URL**: `/Sum`
- **Método**: `POST`
- **Corpo**:
  ```json
  { "id": 41 }
  ```
- **Exemplo**:
  ```bash
  curl -X POST https://localhost:7038/Sum \
       -H "Content-Type: application/json" \
       -d '{"id":41}'
  ```

## CpfILoggerController

Valida um CPF utilizando `ILogger`.

- **URL**: `/CpfILogger`
- **Método**: `POST`
- **Corpo**:
  ```json
  { "cpf": "52998224725" }
  ```
- **Exemplo**:
  ```bash
  curl -X POST https://localhost:7038/CpfILogger \
       -H "Content-Type: application/json" \
       -d '{"cpf":"52998224725"}'
  ```

## CpfSerilogController

Valida um CPF utilizando Serilog.

- **URL**: `/CpfSerilog`
- **Método**: `POST`
- **Corpo**:
  ```json
  { "cpf": "52998224725" }
  ```
- **Exemplo**:
  ```bash
  curl -X POST https://localhost:7038/CpfSerilog \
       -H "Content-Type: application/json" \
       -d '{"cpf":"52998224725"}'
  ```
