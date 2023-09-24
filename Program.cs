using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Hosting;
using Exam.Models.Tab1_Models;


class Program
{
    
    public static async Task Main(string[] args)
    {
         string cosmosEndpointUri = "https://localhost:8081";
         string cosmosPrimaryKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        

        var host = CreateHostBuilder(args).Build();
        

          using (var serviceScope = host.Services.CreateScope())
          {
              var services = serviceScope.ServiceProvider;
              var cosmosDB = services.GetRequiredService<CosmosClient>();

              //create an instance of CosmosClient
              CosmosClient cosmosClient = new CosmosClient(cosmosEndpointUri, cosmosPrimaryKey);

              // Create a new database
              string databaseId = "TaskDB"; 
              DatabaseResponse databaseResponse = await cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId);

              // Create a new container
              string containerId = "ProgramDetails"; 
              string partitionKeyPath = "/programTitle"; 
              ContainerResponse containerResponse = await databaseResponse.Database.CreateContainerIfNotExistsAsync(containerId, partitionKeyPath);              
          }
          
        await host.RunAsync();

    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                IConfiguration configuration = hostContext.Configuration;

                services.AddSingleton(configuration);
                services.AddSingleton<CosmosClient>();
                services.AddSingleton<ProgramDetailsRepository>();
                services.AddSingleton(sp => new CosmosClient("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw=="));
            });
}