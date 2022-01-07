FROM bitnami/dotnet-sdk
  RUN rm -rf ./*
  COPY ./* ./
  RUN ls -l 
  RUN dotnet restore EmployeeProject.csproj && dotnet clean EmployeeProject.csproj && dotnet build EmployeeProject.csproj --configuration Release  
FROM mcr.microsoft.com/dotnet/aspnet:5.0
  COPY bin/Release/netcoreapp3.1/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
