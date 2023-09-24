using Exam.DTO.Tab2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab2_Models
{
    public class ApplicationForm
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiBaseUrl = "http://your-api-base-url.com/";

        public async Task<ApplicationFormDTO?> GetApplicationFormAsync(Guid id)
        {
            var response = await httpClient.GetAsync($"{apiBaseUrl}/applicationforms/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApplicationFormDTO>(content);
            }

            return null;
        }

        protected async Task<HttpResponseMessage> PutAsync(string url, object content)
        {
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PutAsync(url, jsonContent);
        }

    }
}
