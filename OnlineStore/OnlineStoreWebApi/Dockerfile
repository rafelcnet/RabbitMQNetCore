FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
WORKDIR /app/
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY /. ./
WORKDIR /app/
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim-arm32v7 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "OnlineStoreWebApi.dll"]