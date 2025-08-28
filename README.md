
dotnet new sln -n MyApp

dotnet new console -n MyApp.Console

dotnet sln MyApp.sln add MyApp.Console/MyApp.Console.csproj

dotnet build MyApp.sln

dotnet run --project path/to/YourProject.csproj

------------------------------------------------------------------------
