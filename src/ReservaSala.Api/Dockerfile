FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

COPY . ./
COPY *.sln .
COPY ReservaSala.Api/*.csproj ./ReservaSala.Api/
COPY ReservaSala.Core/*.csproj ./ReservaSala.Core/

RUN dotnet restore 

COPY ReservaSala.Api/ ./ReservaSala.Api/
COPY ReservaSala.Core/ ./ReservaSala.Core/


RUN dotnet build --no-restore -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "ReservaSala.Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ReservaSala.Api.dll