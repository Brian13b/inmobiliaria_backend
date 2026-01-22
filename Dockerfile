FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["Inmobiliaria.API/Inmobiliaria.API.csproj", "Inmobiliaria.API/"]
COPY ["Inmobiliaria.Domain/Inmobiliaria.Domain.csproj", "Inmobiliaria.Domain/"]
COPY ["Inmobiliaria.Infrastructure/Inmobiliaria.Infrastructure.csproj", "Inmobiliaria.Infrastructure/"]

RUN dotnet restore "Inmobiliaria.API/Inmobiliaria.API.csproj"

COPY . .
WORKDIR "/src/Inmobiliaria.API"
RUN dotnet build "Inmobiliaria.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inmobiliaria.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inmobiliaria.API.dll"]