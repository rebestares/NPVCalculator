FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY NPVCalculator.WebUI/NPVCalculator.WebUI.csproj NPVCalculator.WebUI/
RUN dotnet restore NPVCalculator.WebUI/NPVCalculator.WebUI.csproj
COPY . .
WORKDIR /src/NPVCalculator.WebUI
RUN dotnet build NPVCalculator.WebUI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish NPVCalculator.WebUI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NPVCalculator.WebUI.dll"]
