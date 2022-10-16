FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SpendingApp/SpendingApp.csproj", "SpendingApp/"]
RUN dotnet restore "SpendingApp/SpendingApp.csproj"
COPY . .
WORKDIR "/src/SpendingApp"
RUN dotnet build "SpendingApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpendingApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpendingApp.dll"]
