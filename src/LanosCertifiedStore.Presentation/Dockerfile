FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/LanosCertifiedStore.Presentation/LanosCertifiedStore.Presentation.csproj", "src/LanosCertifiedStore.Presentation/"]
COPY ["src/LanosCertifiedStore.Application/LanosCertifiedStore.Application.csproj", "src/LanosCertifiedStore.Application/"]
COPY ["src/LanosCertifiedStore.Domain/LanosCertifiedStore.Domain.csproj", "src/LanosCertifiedStore.Domain/"]
COPY ["src/LanosCertifiedStore.Infrastructure/LanosCertifiedStore.Infrastructure.csproj", "src/LanosCertifiedStore.Infrastructure/"]
COPY ["src/LanosCertifiedStore.Persistence/LanosCertifiedStore.Persistence.csproj", "src/LanosCertifiedStore.Persistence/"]
RUN dotnet restore "src/LanosCertifiedStore.Presentation/LanosCertifiedStore.Presentation.csproj"
COPY . .
WORKDIR "/src/src/LanosCertifiedStore.Presentation"
RUN dotnet build "LanosCertifiedStore.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LanosCertifiedStore.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Оновлена частина: копіювання файлу безпосередньо у фінальну стадію
RUN mkdir -p /app/wwwroot/Data/Json
COPY src/LanosCertifiedStore.Presentation/wwwroot/Data/Json/SerializedUkraineLocations.json /app/wwwroot/Data/Json/

ENTRYPOINT ["dotnet", "LanosCertifiedStore.Presentation.dll"]
