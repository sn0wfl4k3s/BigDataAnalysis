# BigDataAnalysis
big data analysis using apache sparks for .net core with docker.

Docker image: https://github.com/indy-3rdman/docker-dotnet-spark



Commands:

docker ps

docker exec -it CONTAINER_ID /bin/bash

cd /bin/Debug/netcoreapp3.1/

spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner \
--master local microsoft-spark-2.4.x-0.11.0.jar dotnet mySparkApp.dll
