FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /app

COPY . ./
RUN dotnet publish ./src/MatchBet.BetsApi/MatchBet.BetsApi.csproj -c Release -o out 


FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 5168
ENTRYPOINT ["dotnet", "MatchBet.BetsApi.dll"]