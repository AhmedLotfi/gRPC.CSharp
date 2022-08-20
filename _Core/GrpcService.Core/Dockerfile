FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GrpcService.Core/GrpcService.Core.csproj", "GrpcService.Core/"]
RUN dotnet restore "GrpcService.Core/GrpcService.Core.csproj"
COPY . .
WORKDIR "/src/GrpcService.Core"
RUN dotnet build "GrpcService.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcService.Core.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcService.Core.dll"]