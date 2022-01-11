#FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["EmployeeProject.csproj", "EmployeeProject/"]

RUN dotnet restore "EmployeeProject/EmployeeProject.csproj"
COPY  . "EmployeeProject/"
WORKDIR "/src/EmployeeProject"
RUN dotnet build "EmployeeProject.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EmployeeProject.csproj" -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
