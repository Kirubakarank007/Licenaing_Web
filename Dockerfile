FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app


COPY . .

COPY ImportData.db /app/ImportData.db


RUN dotnet restore Licensing_Web.csproj
RUN dotnet publish Licensing_Web.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
RUN useradd -m appuser
USER appuser

WORKDIR /app
COPY --from=build /app/out .