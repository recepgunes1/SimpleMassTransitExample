FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SimpleMassTransitExample.Consumer/SimpleMassTransitExample.Consumer.csproj", "SimpleMassTransitExample.Consumer/"]
COPY ["SimpleMassTransitExample.SharedLibrary/SimpleMassTransitExample.SharedLibrary.csproj", "SimpleMassTransitExample.SharedLibrary/"]
RUN dotnet restore "SimpleMassTransitExample.Consumer/SimpleMassTransitExample.Consumer.csproj"
COPY . .
WORKDIR "/src/SimpleMassTransitExample.Consumer"
RUN dotnet build "SimpleMassTransitExample.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleMassTransitExample.Consumer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleMassTransitExample.Consumer.dll"]
