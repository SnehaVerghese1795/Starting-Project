using Exam.DTO.Tab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab2_Models
{
    public class Profile
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiBaseUrl = "http://your-api-base-url.com/";

        public async Task CreateProfile(ProfileDTO newProfile)
        {
            Console.WriteLine("You entered the following Profile Details:");
            Console.WriteLine($"Education: {newProfile.Education}");
            Console.WriteLine($"Experience: {newProfile.Experience}");
            Console.WriteLine($"Resume Path: {newProfile.ResumePath}");

            var postResponse = await PostAsync($"{apiBaseUrl}/profile", newProfile);

            if (postResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Profile created successfully.");

                await ReadAndUpdateProfile();
            }
            else
            {
                Console.WriteLine("Failed to create the profile.");
            }
        }

        protected async Task ReadAndUpdateProfile()
        {
            var profile = await GetProfileAsync();

            if (profile != null)
            {
                Console.WriteLine($"Education: {profile.Education}");
                Console.WriteLine($"Experience: {profile.Experience}");
                Console.WriteLine($"Resume Path: {profile.ResumePath}");
                
                profile.Education = new SlideButton();
                profile.Experience = new SlideButton();

                var putResponse = await PutAsync($"{apiBaseUrl}/profile", profile);

                if (putResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Profile updated successfully.");

                    var deleteResponse = await DeleteAsync($"{apiBaseUrl}/profile");

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Profile deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to delete the profile.");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to update the profile.");
                }
            }
            else
            {
                Console.WriteLine("Failed to read the profile.");
            }
        }

        protected async Task<ProfileDTO> GetProfileAsync()
        {
            var getResponse = await httpClient.GetAsync($"{apiBaseUrl}/profile");

            if (getResponse.IsSuccessStatusCode)
            {
                var profileJson = await getResponse.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<ProfileDTO>(profileJson);
            }

            return null;
        }

        protected async Task<HttpResponseMessage> PostAsync(string url, object content)
        {
            var jsonContent = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PostAsync(url, jsonContent);
        }

        protected async Task<HttpResponseMessage> PutAsync(string url, object content)
        {
            var jsonContent = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PutAsync(url, jsonContent);
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await httpClient.DeleteAsync(url);
        }
    }
}
