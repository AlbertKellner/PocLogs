# PocLogs
Este repositório contém um exemplo simples de microserviço em .NET 8.

O projeto `PocLogs.Api` expõe as seguintes controllers:

- `SumController` com uma action `Post` que recebe um objeto contendo uma propriedade `Id` (tipo `long`) e retorna o valor de `Id` somado a `1`.
- `CpfController` com a action `validate` que recebe um CPF em formato de string e retorna `true` ou `false` indicando se o CPF é válido.

Há também o projeto de testes `PocLogs.Tests` que valida o comportamento dessas actions utilizando xUnit.
