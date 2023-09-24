using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Hosting;
using Exam.Models.Tab1_Models;
using Exam.Models.Tab2_Models;
using Exam.Models.Tab3;
using Exam.Models.Tab3_Models;

class Program
{
    
    public static async Task Main(string[] args)
    {
         string cosmosEndpointUri = "https://localhost:8081";
         string cosmosPrimaryKey = "";
        

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

              // Create a new container
              string appFormContainerId = "ApplicationForm";
              string appFormPartitionKeyPath = "/Id";
              ContainerResponse appFormContainerResponse = await databaseResponse.Database.CreateContainerIfNotExistsAsync(containerId, partitionKeyPath);

              // Create a new container
              string workFlowContainerId = "WorkFlow";
              string workFlowPartitionKeyPath = "/WorkFlowId";
              ContainerResponse workFlowContainerResponse = await databaseResponse.Database.CreateContainerIfNotExistsAsync(containerId, partitionKeyPath);

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
                services.AddSingleton(sp => new CosmosClient("https://localhost:8081", ""));
                services.AddSingleton<AdditionalInformationRepository>();
                services.AddSingleton<ApplicationFormRepository>();
                services.AddSingleton<PersonalInformationRepository>();
                services.AddSingleton<ProfileRepository>();
                services.AddSingleton<QuestionsRepository>();
                services.AddSingleton<AdditionalQuestionsRepository>();
                services.AddSingleton<StageTypeRepository>();
                services.AddSingleton<WorkFlowRepository>();
            });
}