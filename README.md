# AB.Extensions
This is were I keep my middleware packages for Asp.Net Core.  Credit to Steve Gordon's [CorrelationId Repo](https://github.com/stevejgordon/CorrelationId) for getting me online with the best middleware and thread safe context classes for middleware.

The source now officially lives in Azure DevOps, but is continuously pushed to Github via Azure Pipelines CI.



__Feature Build__

[![Primary Build in Azure Pipelines](https://zep519.visualstudio.com/AB.Middleware%20Github%20Project/_apis/build/status/AB.Middleware%20Github%20Project)](https://zep519.visualstudio.com/AB.Middleware%20Github%20Project/_apis/build/status/AB.Middleware%20Github%20Project?branchName=master)


__CI Sync to Github__

[![CI Sync](https://zep519.visualstudio.com/AB.Middleware%20Github%20Project/_apis/build/status/Sync%20to%20Github)](https://zep519.visualstudio.com/AB.Middleware%20Github%20Project/_apis/build/status/Sync%20to%20Github?branchName=master)

Import easily by editing your Csproj:

``<PackageReference Include="AB.Middleware.ClientApplicationId" Version="2.0.0" />``

Alternatively with dotnet CLI:

``dotnet add package AB.Middleware.ClientApplicationId``


## CI Packaging
The Azure Artifacts feed which hosts the prerelease packages (uploaded by CI) is publically available at: https://zep519.pkgs.visualstudio.com/_packaging/Ab.Extensions-CI/nuget/v3/index.json

Release versions are automatically uploaded to Nuget.org by CI under the following conditions:
- master branch
- all previous steps succeeded in the build
- manual queue of build
- when manually queuing the build, a variable of name ```PushReleaseNuget``` should be provided with value ```confirm```

This means that when making new branches for code modifications, it's a good practice to immediately identify the desired SemVer in the csproj metadata, and ensure the code change adheres accordingly.