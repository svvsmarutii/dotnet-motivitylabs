FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["EmployeeProject.csproj", "EmployeeProject/"]

RUN dotnet restore "EmployeeProject/EmployeeProject.csproj" -r linux-musl-x64
COPY  . "EmployeeProject/"
WORKDIR "/src/EmployeeProject"
RUN dotnet build "EmployeeProject.csproj" -c Release -r linux-musl-x64 -o /app --no-restore

FROM build AS publish
RUN dotnet publish "EmployeeProject.csproj" -c Release -r linux-musl-x64 -o /app --no-restore

FROM base AS final
WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
