#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Presentation/Sales.WebApi/Sales.WebApi.csproj", "src/Presentation/Sales.WebApi/"]
COPY ["src/Infrastructure/Sale.Persistence/Sales.Persistence.csproj", "src/Infrastructure/Sale.Persistence/"]
COPY ["src/Core/Sales.Application/Sales.Application.csproj", "src/Core/Sales.Application/"]
COPY ["src/Core/Sales.Domain/Sales.Domain.csproj", "src/Core/Sales.Domain/"]
RUN dotnet restore "src/Presentation/Sales.WebApi/Sales.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Sales.WebApi"
RUN dotnet build "Sales.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sales.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.WebApi.dll"]