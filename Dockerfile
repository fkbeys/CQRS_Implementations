FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
  
COPY . .
WORKDIR "/src/src/Presentation/Sales.WebApi"
RUN dotnet build "Sales.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sales.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sales.WebApi.dll"]
