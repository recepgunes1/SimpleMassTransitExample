FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SimpleMassTransitExample.Producer/SimpleMassTransitExample.Producer.csproj", "SimpleMassTransitExample.Producer/"]
COPY ["SimpleMassTransitExample.SharedLibrary/SimpleMassTransitExample.SharedLibrary.csproj", "SimpleMassTransitExample.SharedLibrary/"]
RUN dotnet restore "SimpleMassTransitExample.Producer/SimpleMassTransitExample.Producer.csproj"
COPY . .
WORKDIR "/src/SimpleMassTransitExample.Producer"
RUN dotnet build "SimpleMassTransitExample.Producer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleMassTransitExample.Producer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleMassTransitExample.Producer.dll"]
