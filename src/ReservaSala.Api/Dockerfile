#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base

WORKDIR /app

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore 

RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet ReservaSala.Api.dll

 