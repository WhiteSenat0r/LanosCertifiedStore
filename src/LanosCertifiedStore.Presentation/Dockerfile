#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LanosCertifiedStore.Presentation/LanosCertifiedStore.Presentation.csproj", "LanosCertifiedStore.Presentation/"]
COPY ["LanosCertifiedStore.Application/LanosCertifiedStore.Application.csproj", "LanosCertifiedStore.Application/"]
COPY ["LanosCertifiedStore.Domain/LanosCertifiedStore.Domain.csproj", "LanosCertifiedStore.Domain/"]
COPY ["LanosCertifiedStore.Infrastructure/LanosCertifiedStore.Infrastructure.csproj", "LanosCertifiedStore.Infrastructure/"]
COPY ["LanosCertifiedStore.Persistence/LanosCertifiedStore.Persistence.csproj", "LanosCertifiedStore.Persistence/"]
RUN dotnet restore "./LanosCertifiedStore.Presentation/LanosCertifiedStore.Presentation.csproj"
COPY . .
WORKDIR "/src/LanosCertifiedStore.Presentation"
RUN dotnet build "./LanosCertifiedStore.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./LanosCertifiedStore.Presentation.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LanosCertifiedStore.Presentation.dll"]