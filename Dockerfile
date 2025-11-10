# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj y restaurar dependencias
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["RepositoryEntityFrameworkSqlServer/RepositoryEntityFrameworkSqlServer.csproj", "RepositoryEntityFrameworkSqlServer/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]

RUN dotnet restore "WebApi/WebApi.csproj"

# Copiar todo el código y publicar
COPY . .
WORKDIR /src/WebApi
RUN dotnet publish -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]
