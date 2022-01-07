FROM bitnami/dotnet-sdk
  COPY ./* ./
  RUN ls -l 
  RUN dotnet restore EmployeeProject/EmployeeProject.csproj
FROM mcr.microsoft.com/dotnet/aspnet:5.0
  COPY bin/Release/netcoreapp3.1/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
