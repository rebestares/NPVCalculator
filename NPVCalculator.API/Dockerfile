FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY NPVCalculator.API/NPVCalculator.API.csproj NPVCalculator.API/
RUN dotnet restore NPVCalculator.API/NPVCalculator.API.csproj
COPY . .
WORKDIR /src/NPVCalculator.API
RUN dotnet build NPVCalculator.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NPVCalculator.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NPVCalculator.API.dll"]
