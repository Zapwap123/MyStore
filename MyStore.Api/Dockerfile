# Use the official ASP.NET Core runtime image as a base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MyStore.Api/MyStore.Api.csproj", "MyStore.Api/"]
RUN dotnet restore "MyStore.Api/MyStore.Api.csproj"

COPY . .
WORKDIR "/src/MyStore.Api"
RUN dotnet build "MyStore.Api.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "MyStore.Api.csproj" -c Release -o /app/publish

# Final stage: run the app in the ASP.NET Core runtime environment
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyStore.Api.dll"]
