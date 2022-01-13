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

RUN pwd \
    && find / -name EmployeeProject.dll \
    && dotnet tool install --global --version 5.3.1 Swashbuckle.AspNetCore.Cli \
    && export PATH="$PATH:/root/.dotnet/tools" \
    && ls -l /root/.dotnet/tools \
    && chmod +x /root/.dotnet/tools/swagger \
    && echo $PATH \
    && dotnet --help
    
RUN dotnet-swagger tofile --output swagger.json /app/EmployeeProject.dll v1

FROM build AS publish
RUN dotnet publish "EmployeeProject.csproj" -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
