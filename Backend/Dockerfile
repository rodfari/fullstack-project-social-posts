# Use the SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the solution and project files
COPY Backend.sln ./
COPY Core/Domain/Domain.csproj Core/Domain/
COPY Core/Application/Application.csproj Core/Application/
COPY Consumer/Api/Consumer.csproj Consumer/Api/
COPY Infrastructure/Persistence/mySQL/mySQL.csproj Infrastructure/Persistence/mySQL/
COPY Tests/ApplicationTests/ApplicationTests.csproj Tests/ApplicationTests/
COPY Tests/PersistenceTests/PersistenceTests.csproj Tests/PersistenceTests/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the application code
COPY . .

# Build and publish the application
RUN dotnet publish -c Debug -o out

# Use the runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /app/out .

# ENV ASPNETCORE_ENVIRONMENT=Development
# ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Consumer.dll"]