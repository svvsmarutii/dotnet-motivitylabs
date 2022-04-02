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

ARG SONAR=true
RUN dotnet restore "EmployeeProject/EmployeeProject.csproj"
COPY  . "EmployeeProject/"
WORKDIR "/src/EmployeeProject"
RUN dotnet build "EmployeeProject.csproj" -c Release -o /app
RUN dotnet new tool-manifest
RUN pwd \
    && dotnet tool install --local --version 6.2.2 Swashbuckle.AspNetCore.Cli \
    && find / -name dotnet-tools.json \
    && cat /src/EmployeeProject/.config/dotnet-tools.json
    
RUN dotnet tool run swagger tofile --output swagger.json bin/Debug/netcoreapp3.1/EmployeeProject.dll v1

RUN if [ "$SONAR" = true ] ; then \
    apt-get update && apt-get install -y openjdk-11-jdk \
    && dotnet tool install -g dotnet-sonarscanner \
    && dotnet tool install -g dotnet-reportgenerator-globaltool \
    && export PATH="${PATH}:/root/.dotnet/tools" \
    && dotnet sonarscanner begin \
    /k:EmployeeProject \
    /d:sonar.host.url=http://3.109.121.132:9000/ \
    /d:sonar.branch.name=dindlocaldb \
    /d:sonar.coverageReportPaths="coverage/SonarQube.xml" \
    && dotnet test --collect:"XPlat Code Coverage" --results-directory ./coverage || echo "Tests Failed" \
    && reportgenerator "-reports:./coverage/*/coverage.cobertura.xml" "-targetdir:coverage" "-reporttypes:SonarQube"  || echo "Reportgenerator Failed" \
    && dotnet sonarscanner end; \
    else echo "Sonarscanner Stage Skipped"; \
    fi

RUN ls -lR


FROM build AS publish
RUN dotnet publish "EmployeeProject.csproj" -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
