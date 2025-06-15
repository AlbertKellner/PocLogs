# Processo de CI/CD

Os workflows do GitHub executam testes e verificam a cobertura a cada pull request. A documentação em `wiki/` é publicada automaticamente na Wiki do GitHub.

Para reproduzir localmente, execute:

```bash
dotnet build

dotnet test --collect:"XPlat Code Coverage"
```
