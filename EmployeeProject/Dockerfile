FROM bitnami/dotnet-sdk:5
  RUN pwd && ls -l && rm -rf ./* && ls -l
  #COPY ./EmployeeProject.csproj ./
  RUN ls -l 
  #RUN dotnet restore EmployeeProject.csproj --no-cache && dotnet build EmployeeProject.csproj --configuration Release  
  #RUN dotnet restore EmployeeProject.csproj
  COPY ./* ./
  RUN rm -rf obj bin && rm -f /app/Debug/netcoreapp3.1/EmployeeProject.AssemblyInfo.cs /app/Debug/netcoreapp3.1/EmployeeProject.MvcApplicationPartsAssemblyInfo.cs /app/Debug/netcoreapp3.1/.NETCoreApp,Version=v3.1.AssemblyAttributes.cs && ls -l  
  RUN find /app -name *AssemblyInfo.cs 
  RUN find /app -name *AssemblyAttributes.cs
  RUN dotnet build EmployeeProject.csproj --configuration Release
FROM mcr.microsoft.com/dotnet/aspnet:5.0
  #COPY bin/Release/netcoreapp3.1/ App/
  WORKDIR /App
  ENTRYPOINT ["dotnet", "EmployeeProject.dll"]
