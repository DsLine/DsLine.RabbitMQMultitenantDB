#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DsLine.Stock.Services.Api/DsLine.Stock.Services.Api.csproj", "DsLine.Stock.Services.Api/"]
COPY ["DsLine.Stock.Infra.Repository/DsLine.Stock.Infra.Repository.csproj", "DsLine.Stock.Infra.Repository/"]
COPY ["DsLine.Stock.Models.Entities/DsLine.Stock.Models.Entities.csproj", "DsLine.Stock.Models.Entities/"]
COPY ["DsLine.Core.Models.Entities/DsLine.Core.Models.Entities.csproj", "DsLine.Core.Models.Entities/"]
COPY ["DsLine.Core.Infra.Repository/DsLine.Core.Infra.Repository.csproj", "DsLine.Core.Infra.Repository/"]
RUN dotnet restore "DsLine.Stock.Services.Api/DsLine.Stock.Services.Api.csproj"
COPY . .
WORKDIR "/src/DsLine.Stock.Services.Api"
RUN dotnet build "DsLine.Stock.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DsLine.Stock.Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DsLine.Stock.Services.Api.dll"]
