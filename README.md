# PocLogs
Este repositório contém um exemplo simples de microserviço em .NET 8.

O projeto `PocLogs.Api` expõe uma única controller `SumController` com uma action
que recebe um objeto contendo uma propriedade `Id` (tipo `long`) e retorna o valor
de `Id` somado a `1`.

Há também o projeto de testes `PocLogs.Tests` que valida o comportamento dessa
action utilizando xUnit.
