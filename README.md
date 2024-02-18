## Current Coverage Result:
_(Feb 17, 2024)_
![Screenshot_9](https://github.com/RubenAlonzo/SQA.F8/assets/63566834/d9c2d53d-b876-4d9a-84c4-0d15f2d17c1a)

## Generate new Coverage Result:
As a prerequisite you might need to install NET8 and the following global package:
```
dotnet tool install -g dotnet-reportgenerator-globaltool
```

Run the following commands from the `SQA.F8.Core.Tests` project. 

```
dotnet test --collect:"XPlat Code Coverage"
```
```
dotnet reportgenerator "-reports:path\to\coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html
```
