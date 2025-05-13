FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY . .

# Add NuGet source
RUN dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org

RUN dotnet restore Licensing_Web.csproj
RUN dotnet publish Licensing_Web.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "Licensing_Web.dll"]
