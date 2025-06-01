FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AdocaoAnimais.API/AdocaoAnimais.API.csproj", "AdocaoAnimais.API/"]
COPY ["AdocaoAnimais.Application/AdocaoAnimais.Application.csproj", "AdocaoAnimais.Application/"]
COPY ["AdocaoAnimais.Domain/AdocaoAnimais.Domain.csproj", "AdocaoAnimais.Domain/"]
COPY ["AdocaoAnimais.Infrastructure/AdocaoAnimais.Infrastructure.csproj", "AdocaoAnimais.Infrastructure/"]
RUN dotnet restore "AdocaoAnimais.API/AdocaoAnimais.API.csproj"
COPY . .
WORKDIR "/src/AdocaoAnimais.API"
RUN dotnet build "./AdocaoAnimais.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AdocaoAnimais.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdocaoAnimais.API.dll"]
