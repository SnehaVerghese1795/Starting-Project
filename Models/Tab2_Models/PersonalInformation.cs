using Exam.DTO.Tab2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab2_Models
{
    public class PersonalInformation
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiBaseUrl = "http://your-api-base-url.com/";

        public async Task CreatePersonalInformationAsync()
        {
            var newPersonalInfo = new PersonalInformationDTO
            {
                FirstName = Console.ReadLine(),
                LastName = Console.ReadLine(),
                Email = Console.ReadLine(),
                Phone = int.Parse(Console.ReadLine()),
                Nationality = Console.ReadLine(),
                CurrentResidence = Console.ReadLine(),
                IdNumber = int.Parse(Console.ReadLine()),
                DateOfBirth = DateTime.Parse(Console.ReadLine()),
                Gender = Console.ReadLine()
                
            };

            Console.WriteLine("You entered the following Personal Information:");
            Console.WriteLine($"First Name: {newPersonalInfo.FirstName}");
            Console.WriteLine($"Last Name: {newPersonalInfo.LastName}");
            Console.WriteLine($"Email: {newPersonalInfo.Email}");
            Console.WriteLine($"Phone: {newPersonalInfo.Phone}");
            Console.WriteLine($"Nationality: {newPersonalInfo.Nationality}");
            Console.WriteLine($"Current Residence: {newPersonalInfo.CurrentResidence}");
            Console.WriteLine($"ID Number: {newPersonalInfo.IdNumber}");
            Console.WriteLine($"Date of Birth: {newPersonalInfo.DateOfBirth}");
            Console.WriteLine($"Gender: {newPersonalInfo.Gender}");

            var postResponse = await PostAsync($"{apiBaseUrl}/personalinformation", newPersonalInfo);

            if (postResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Personal Information created successfully.");

                await ReadAndUpdatePersonalInformation("NewType");
            }
            else
            {
                Console.WriteLine("Failed to create Personal Information.");
            }
        }

        public async Task ReadAndUpdatePersonalInformation(string id)
        {
            var personalInfo = await GetPersonalInformationAsync(id);

            if (personalInfo != null)
            {
                Console.WriteLine($"First Name: {personalInfo.FirstName}");
                Console.WriteLine($"Last Name: {personalInfo.LastName}");
                Console.WriteLine($"Email: {personalInfo.Email}");
                Console.WriteLine($"Phone: {personalInfo.Phone}");
                Console.WriteLine($"Nationality: {personalInfo.Nationality}");
                Console.WriteLine($"Current Residence: {personalInfo.CurrentResidence}");
                Console.WriteLine($"ID Number: {personalInfo.IdNumber}");
                Console.WriteLine($"Date of Birth: {personalInfo.DateOfBirth}");
                Console.WriteLine($"Gender: {personalInfo.Gender}");
                
                personalInfo.FirstName = "Updated First Name";

                var putResponse = await PutAsync($"{apiBaseUrl}/personalinformation/{id}", personalInfo);

                if (putResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Personal Information updated successfully.");

                    var deleteResponse = await DeleteAsync($"{apiBaseUrl}/personalinformation/{id}");

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Personal Information deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to delete Personal Information.");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to update Personal Information.");
                }
            }
            else
            {
                Console.WriteLine("Failed to read Personal Information.");
            }
        }

        public async Task<PersonalInformationDTO> GetPersonalInformationAsync(string id)
        {
            var getResponse = await httpClient.GetAsync($"{apiBaseUrl}/personalinformation/{id}");

            if (getResponse.IsSuccessStatusCode)
            {
                var personalInfoJson = await getResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PersonalInformationDTO>(personalInfoJson);
            }

            return null;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PostAsync(url, jsonContent);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, object content)
        {
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PutAsync(url, jsonContent);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await httpClient.DeleteAsync(url);
        }
    }
}
