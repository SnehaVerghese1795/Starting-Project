using Exam.DTO.Tab1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab1_Models
{
    public class AdditionalInformation
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiBaseUrl = "http://your-api-base-url.com/";

        public static async Task CreateAdditionalInformation()
        {
            var newAdditionalInfo = new AdditionalInformationDTO
            {
                ProgramType = Console.ReadLine(),
                ProgramStart = DateTime.Parse(Console.ReadLine()),
                ApplicationOpen = DateTime.Parse(Console.ReadLine()),
                ApplicationClose = DateTime.Parse(Console.ReadLine()),
                Duration = Console.ReadLine(),
                ProgramLocation = Console.ReadLine(),
                MinQualifications = Console.ReadLine(),
                MaxNoOfApplication = int.Parse(Console.ReadLine())
            };

            Console.WriteLine("You entered the following Additional Details:");
            Console.WriteLine($"Program Type: {newAdditionalInfo.ProgramType}");
            Console.WriteLine($"Program Start: {newAdditionalInfo.ProgramStart}");
            Console.WriteLine($"Application Open: {newAdditionalInfo.ApplicationOpen}");
            Console.WriteLine($"Application Close: {newAdditionalInfo.ApplicationClose}");
            Console.WriteLine($"Duration: {newAdditionalInfo.Duration}");
            Console.WriteLine($"Program Location: {newAdditionalInfo.ProgramLocation}");
            Console.WriteLine($"Min Qualifications: {newAdditionalInfo.MinQualifications}");
            Console.WriteLine($"Max Number of Applications: {newAdditionalInfo.MaxNoOfApplication}");


            var postResponse = await PostAsync($"{apiBaseUrl}/additionalinformation", newAdditionalInfo);

            if (postResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Additional Information created successfully.");

                await ReadAndUpdateAdditionalInformation("New Type");
            }
            else
            {
                Console.WriteLine("Failed to create Additional Information.");
            }
        }

        protected static async Task ReadAndUpdateAdditionalInformation(string programType)
        {
            var additionalInfo = await GetAdditionalInformationAsync(programType);

            if (additionalInfo != null)
            {
                Console.WriteLine($"Type: {additionalInfo.ProgramType}");
                Console.WriteLine($"Start Date: {additionalInfo.ProgramStart}");
                Console.WriteLine($"Application Open: {additionalInfo.ApplicationOpen}");
                Console.WriteLine($"Application Close: {additionalInfo.ApplicationClose}");
                Console.WriteLine($"Duration: {additionalInfo.Duration}");
                Console.WriteLine($"Program Location: {additionalInfo.ProgramLocation}");
                Console.WriteLine($"Min Qualifications: {additionalInfo.MinQualifications}");
                Console.WriteLine($"Max Number of Applications: {additionalInfo.MaxNoOfApplication}");
                
                additionalInfo.ProgramType = "Updated Type";

                var putResponse = await PutAsync($"{apiBaseUrl}/additionalinformation/{programType}", additionalInfo);

                if (putResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Additional Information updated successfully.");

                    var deleteResponse = await DeleteAsync($"{apiBaseUrl}/additionalinformation/{programType}");

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Additional Information deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to delete Additional Information.");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to update Additional Information.");
                }
            }
            else
            {
                Console.WriteLine("Failed to read Additional Information.");
            }
        }

        protected static async Task<AdditionalInformationDTO> GetAdditionalInformationAsync(string programType)
        {
            var getResponse = await httpClient.GetAsync($"{apiBaseUrl}/additionalinformation/{programType}");

            if (getResponse.IsSuccessStatusCode)
            {
                var additionalInfoJson = await getResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AdditionalInformationDTO>(additionalInfoJson);
            }

            return null;
        }

        protected static async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PostAsync(url, jsonContent);
        }

        protected static async Task<HttpResponseMessage> PutAsync(string url, object content)
        {
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(content),
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
