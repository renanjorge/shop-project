#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV DB_HOST=172.17.0.2
ENV DB_PORT=1433
ENV DB_NAME=shopdb
ENV DB_USER=sa
ENV DB_SA_PASSWORD=Password#123

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["shop.api/shop.api.csproj", "shop.api/"]
COPY ["shop.domain/shop.domain.csproj", "shop.domain/"]
COPY ["shop.infra.crossCutting/shop.infra.crossCutting.csproj", "shop.infra.crossCutting/"]
COPY ["shop.infra.data/shop.infra.data.csproj", "shop.infra.data/"]
COPY ["shop.service/shop.service.csproj", "shop.service/"]
RUN dotnet restore "./shop.api/./shop.api.csproj"
COPY . .
WORKDIR "/src/shop.api"
RUN dotnet build "./shop.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./shop.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "shop.api.dll"]
