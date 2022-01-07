FROM bitnami/dotnet-sdk
  RUN pwd && ls -l && rm -rf ./* && ls -l
  #COPY ./EmployeeProject.csproj ./
  RUN ls -l 
  #RUN dotnet restore EmployeeProject.csproj --no-cache && dotnet build EmployeeProject.csproj --configuration Release  
  #RUN dotnet restore EmployeeProject.csproj
  COPY ./* ./
  RUN dotnet build EmployeeProject.csproj --configuration Release
FROM mcr.microsoft.com/dotnet/aspnet:5.0
  #COPY bin/Release/netcoreapp3.1/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
