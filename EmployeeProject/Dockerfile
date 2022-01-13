#FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 40386

#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["EmployeeProject.csproj", "EmployeeProject/"]

RUN dotnet restore "EmployeeProject/EmployeeProject.csproj"
COPY  . "EmployeeProject/"
WORKDIR "/src/EmployeeProject"
RUN dotnet build "EmployeeProject.csproj" -c Release -o /app
RUN dotnet new tool-manifest
RUN pwd \
    && find / -name dotnet-tools.json \
    && dotnet tool install --global --version 6.2.2 Swashbuckle.AspNetCore.Cli \
    && cat /src/EmployeeProject/.config/dotnet-tools.json \
    && export PATH="$PATH:/root/.dotnet/tools" \
    && ls -l /root/.dotnet/tools \
    && chmod +x /root/.dotnet/tools/swagger \
    && echo $PATH
    
RUN dotnet tool run dotnet-swagger tofile --output swagger.json bin/Debug/netcoreapp3.1/EmployeeProject.dll v1

FROM build AS publish
RUN dotnet publish "EmployeeProject.csproj" -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
