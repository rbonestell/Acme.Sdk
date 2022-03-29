#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Acme.Sdk.Api/Acme.Sdk.Api.csproj", "Acme.Sdk.Api/"]
COPY ["Acme.Sdk.Common/Acme.Sdk.Common.csproj", "Acme.Sdk.Common/"]
RUN dotnet restore "Acme.Sdk.Api/Acme.Sdk.Api.csproj"
COPY . .
WORKDIR "/src/Acme.Sdk.Api"
RUN dotnet build "Acme.Sdk.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Acme.Sdk.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Acme.Sdk.Api.dll"]
