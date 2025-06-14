Antes de qualquer commit, execute:
1. `dotnet build`
2. `dotnet test`
3. `dotnet test --collect:"XPlat Code Coverage"`
   Se algum arquivo estiver abaixo de **99%** de cobertura, atualize ou escreva novos testes e repita a verificação de cobertura até que todos os arquivos estejam no mínimo com **99%**.
Se algum build ou teste falhar, corrija os erros antes de commitar.
Toda a comunicação com o usuário e toda a documentação devem estar em português.
Não adicione automaticamente o atributo `[ExcludeFromCodeCoverage]` a nenhum arquivo, a menos que o usuário peça explicitamente.
