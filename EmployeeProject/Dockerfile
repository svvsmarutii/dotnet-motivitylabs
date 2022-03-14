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
    && dotnet tool install --local --version 6.2.2 Swashbuckle.AspNetCore.Cli \
    && find / -name dotnet-tools.json \
    && cat /src/EmployeeProject/.config/dotnet-tools.json
    
RUN dotnet tool run swagger tofile --output swagger.json bin/Debug/netcoreapp3.1/EmployeeProject.dll v1

FROM build AS sonar-yes
RUN dotnet tool install -g dotnet-sonarscanner && dotnet tool install -g dotnet-reportgenerator-globaltool
ENV PATH "${PATH}:/root/.dotnet/tools"
COPY --from=build /src/EmployeeProject/ /src/EmployeeProject
WORKDIR /src/EmployeeProject

# initialize the dotnet specific scanner
RUN dotnet sonarscanner begin \
	/k:testimplementation \
    /name:testimplementation \
    /d:sonar.host.url=http://3.109.121.132:9000/ \
    /d:sonar.branch.name=dindlocaldb \
	/d:sonar.coverageReportPaths="coverage/SonarQube.xml"

## Run dotnet test setting the output on the /coverage folder
#RUN dotnet test --filter "DisplayName!~TextCompressorTests" --collect:"XPlat Code Coverage" --results-directory ./coverage
RUN dotnet test --collect:"XPlat Code Coverage" --results-directory ./coverage ; exit 0

## Create the code coverage file in sonarqube format using the cobertura file generated from the dotnet test command
RUN reportgenerator "-reports:./coverage/*/coverage.cobertura.xml" "-targetdir:coverage" "-reporttypes:SonarQube"

## Stop scanner
RUN dotnet sonarscanner end

FROM build AS sonar-no
COPY --from=build /src/EmployeeProject/ /src/EmployeeProject

FROM sonar-${boolvalue} as build

FROM build AS publish
RUN dotnet publish "EmployeeProject.csproj" -c Release -o /app --no-restore

FROM base AS final
WORKDIR /app

COPY --from=publish /app .

ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
