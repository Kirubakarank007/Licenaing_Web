# Base runtime image (Linux-based)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Licensing_Web.csproj", "."]
RUN dotnet restore "./Licensing_Web.csproj"

COPY . .
WORKDIR "/src/."
RUN dotnet build "./Licensing_Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Licensing_Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime stage
FROM base AS final
WORKDIR /app

# Ensure database directory exists
RUN mkdir -p /app/Data

# Copy published files
COPY --from=publish /app/publish .

# Copy SQLite database
COPY ImportData.db /app/Data/

# Set correct permissions for SQLite database
RUN chmod -R 777 /app/Data

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Licensing_Web.dll"]
