FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["IncomeService/IncomeService.csproj", "IncomeService/"]
RUN dotnet restore "IncomeService/IncomeService.csproj"
COPY . .
WORKDIR "/src/IncomeService"
RUN dotnet build "IncomeService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IncomeService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncomeService.dll"]