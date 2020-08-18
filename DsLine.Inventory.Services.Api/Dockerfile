#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DsLine.Inventory.Services.Api/DsLine.Inventory.Services.Api.csproj", "DsLine.Inventory.Services.Api/"]
RUN dotnet restore "DsLine.Inventory.Services.Api/DsLine.Inventory.Services.Api.csproj"
COPY . .
WORKDIR "/src/DsLine.Inventory.Services.Api"
RUN dotnet build "DsLine.Inventory.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DsLine.Inventory.Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DsLine.Inventory.Services.Api.dll"]