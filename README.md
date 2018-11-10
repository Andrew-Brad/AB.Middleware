# AB.Extensions
This is an extensions library I've built up over time, free of external dependencies, with constantly increasing test coverage and benchmarks.  Constant strings, simple enums, and missing LINQ methods are all part of this library.

The source now officially lives in Azure DevOps, but is continuously pushed to Github via Azure Pipelines CI.



__Feature Build__

[![Primary Build in Azure Pipelines](https://zep519.visualstudio.com/AB.Extensions%20Github%20Project/_apis/build/status/AB.Extensions%20Github%20Project)](https://zep519.visualstudio.com/AB.Extensions%20Github%20Project/_build?definitionId=2)


__CI Sync to Github__

[![CI Sync](https://zep519.visualstudio.com/AB.Extensions%20Github%20Project/_apis/build/status/Sync%20to%20Github)](https://zep519.visualstudio.com/AB.Extensions%20Github%20Project/_build/latest?definitionId=3)

Import easily by editing your Csproj:

``<PackageReference Include="AB.Extensions" Version="3.0.0" />``

Alternatively with dotnet CLI:

``dotnet add package AB.Extensions``


## CI Packaging
The Azure Artifacts feed which hosts the prerelease packages (uploaded by CI) is publically available at: https://zep519.pkgs.visualstudio.com/_packaging/Ab.Extensions-CI/nuget/v3/index.json

Release versions are automatically uploaded to Nuget.org by CI under the following conditions:
- master branch
- all previous steps succeeded in the build
- manual queue of build
- when manually queuing the build, a variable of name ```PushReleaseNuget``` should be provided with value ```confirm```

This means that when making new branches for code modifications, it's a good practice to immediately identify the desired SemVer in the csproj metadata, and ensure the code change adheres accordingly.