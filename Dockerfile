FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS dotnet-build-env
WORKDIR /src
COPY . .
RUN dotnet restore
WORKDIR /src/Personal.Api
RUN dotnet build "Personal.Api.csproj" -c Release -o /app

FROM dotnet-build-env AS publish
WORKDIR /src/Personal.Api
RUN dotnet publish "Personal.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Personal.Api.dll", "--server.urls", "http://0.0.0.0:5000"]