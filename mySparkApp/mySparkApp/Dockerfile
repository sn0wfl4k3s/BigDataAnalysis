#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM 3rdman/dotnet-spark:latest AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["mySparkApp/mySparkApp.csproj", "mySparkApp/"]
RUN dotnet restore "mySparkApp/mySparkApp.csproj"
COPY . .
WORKDIR "/src/mySparkApp"
RUN dotnet build "mySparkApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "mySparkApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "mySparkApp.dll"]
#%SPARK_HOME%\bin\spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner --master local bin\Debug\netcoreapp3.1\microsoft-spark-2.4.x-0.11.0.jar dotnet bin\Debug\netcoreapp3.1\mySparkApp.dll
