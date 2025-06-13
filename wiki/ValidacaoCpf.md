# Validação de CPF

O projeto possui duas implementações de validação de CPF:

- `CpfValidatorWithILogger` usa o `ILogger` da ASP.NET Core.
- `CpfValidatorWithSerilog` usa o logger do Serilog.

Ambas seguem o mesmo algoritmo:

1. Remover todos os caracteres que não sejam dígitos.
2. Verificar se existem 11 dígitos e se não são todos iguais.
3. Calcular os dois dígitos verificadores e comparar com o CPF informado.

Exemplo de uso:

```csharp
var validator = new CpfValidatorWithILogger(logger);
bool valido = validator.IsValid("529.982.247-25");
```

O método retorna `true` para CPFs válidos e `false` caso contrário. Além disso, as informações de validação são registradas pelo logger escolhido.
