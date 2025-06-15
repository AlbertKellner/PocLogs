# Exemplos de Uso via curl

```bash
# Somar 1 ao valor enviado
curl -X POST https://localhost:7038/Sum \
     -H "Content-Type: application/json" \
     -d '{"id": 41}'

# Validar CPF com ILogger
curl -X POST https://localhost:7038/CpfILogger \
     -H "Content-Type: application/json" \
     -d '{"cpf": "52998224725"}'

# Validar CPF com Serilog
curl -X POST https://localhost:7038/CpfSerilog \
     -H "Content-Type: application/json" \
     -d '{"cpf": "52998224725"}'
```
