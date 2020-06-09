using Microsoft.Spark.Sql;

namespace mySparkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                docker ps

                docker exec -it <CONTAINER ID> /bin/bash

                cd /bin/Debug/netcoreapp3.1/

                spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner \
                --master local microsoft-spark-2.4.x-0.11.0.jar dotnet mySparkApp.dll
             */

            var spark = SparkSession
                .Builder()
                .AppName("word_count_sample")
                .GetOrCreate();

            var dataFrame = spark.Read().Text("input.txt");

            var words = dataFrame
                .Select(Functions.Split(Functions.Col("value"), " ").Alias("words"))
                .Select(Functions.Explode(Functions.Col("words"))
                .Alias("word"))
                .GroupBy("word")
                .Count()
                .OrderBy(Functions.Col("count").Desc());

            words.Show();

            spark.Stop();
        }
    }
}
