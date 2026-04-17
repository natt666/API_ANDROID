# Etapa 1: Base para ejecución (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base

WORKDIR /app

EXPOSE 8080

# Etapa 2: Construcción (SDK)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["simex_api/simex_api/simex_api.csproj", "simex_api/simex_api/"]

RUN dotnet restore "simex_api/simex_api/simex_api.csproj"

COPY . .

RUN dotnet build "simex_api/simex_api/simex_api.csproj" -c Release -o /app/build

# Etapa 3: Publicación
FROM build AS publish

RUN dotnet publish "simex_api/simex_api/simex_api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 4: Imagen final
FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "simex_api.dll"]