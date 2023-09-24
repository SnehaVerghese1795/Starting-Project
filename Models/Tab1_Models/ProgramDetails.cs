using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Exam.DTO.Tab1;
using System.Reflection.Metadata;

namespace Exam.Models.Tab1_Models
{
    public class ProgramDetails
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiBaseUrl = "http://your-api-base-url.com/";

        public static async Task CreateProgram()
        {
            var newProgram = new ProgramDetailsDTO
            {
                ProgramTitle = Console.ReadLine(),
                ProgramSummary = Console.ReadLine(),
                ProgramDescription = Console.ReadLine(),
                ProgramKeySkills = Console.ReadLine(),
                ProgramBenefits = Console.ReadLine(),
                ApplicationCriteria = Console.ReadLine()
            };

            Console.WriteLine("You entered the following Program Details:");
            Console.WriteLine($"Title: {newProgram.ProgramTitle}");
            Console.WriteLine($"Summary: {newProgram.ProgramSummary}");
            Console.WriteLine($"Description: {newProgram.ProgramDescription}");
            Console.WriteLine($"Key Skills: {newProgram.ProgramKeySkills}");
            Console.WriteLine($"Benefits: {newProgram.ProgramBenefits}");
            Console.WriteLine($"Application Criteria: {newProgram.ApplicationCriteria}");

            var postResponse = await PostAsync($"{apiBaseUrl}/programdetails", newProgram);
            
            if (postResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Program created successfully.");

                await ReadAndUpdateProgram("New Program");
            }
            else
            {
                Console.WriteLine("Failed to create the program.");
            }
        }

        protected static async Task ReadAndUpdateProgram(string programTitle)
        {
            var program = await GetProgramAsync(programTitle);

            if (program != null)
            {
                Console.WriteLine($"Title: {program.ProgramTitle}");
                Console.WriteLine($"Summary: {program.ProgramSummary}");

                program.ProgramSummary = "Updated summary";

                var putResponse = await PutAsync($"{apiBaseUrl}/programdetails/{programTitle}", program);

                if (putResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Program updated successfully.");

                    var deleteResponse = await DeleteAsync($"{apiBaseUrl}/programdetails/{programTitle}");

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Program deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to delete the program.");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to update the program.");
                }
            }
            else
            {
                Console.WriteLine("Failed to read the program.");
            }
        }

        protected static async Task<ProgramDetailsDTO> GetProgramAsync(string programTitle)
        {
            var getResponse = await httpClient.GetAsync($"{apiBaseUrl}/programdetails/{programTitle}");

            if (getResponse.IsSuccessStatusCode)
            {
                var programJson = await getResponse.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ProgramDetailsDTO>(programJson);
            }

            return null;
        }

        protected static async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            var jsonContent = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PostAsync(url, jsonContent);
        }

        protected static async Task<HttpResponseMessage> PutAsync(string url, object content)
        {
            var jsonContent = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PutAsync(url, jsonContent);
        }

        protected static async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await httpClient.DeleteAsync(url);
        }
    }
}

