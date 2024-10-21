# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Use the SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AlphabetChecker.API/AlphabetChecker.API.csproj", "AlphabetChecker.API/"]
COPY ["AlphabetChecker.Service/AlphabetChecker.Service.csproj", "AlphabetChecker.Service/"]
COPY ["AlphabetChecker.Domain/AlphabetChecker.Domain.csproj", "AlphabetChecker.Domain/"]
RUN dotnet restore "AlphabetChecker.API/AlphabetChecker.API.csproj"
COPY . .
WORKDIR "/src/AlphabetChecker.API"
RUN dotnet build "AlphabetChecker.API.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "AlphabetChecker.API.csproj" -c Release -o /app/publish

# Use the base image to run the app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlphabetChecker.API.dll"]
