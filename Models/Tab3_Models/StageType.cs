using Exam.DTO.Tab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab3
{
    public class StageType
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiBaseUrl = "http://your-api-base-url.com/";

        public async Task<StageTypeDTO> GetStageTypeAsync(Guid StageId)
        {
            var response = await httpClient.GetAsync($"{apiBaseUrl}/stagetypes/{StageId}");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<StageTypeDTO>(jsonContent);
            }

            return null;
        }

        public async Task<HttpResponseMessage> CreateStageTypeAsync(StageTypeDTO stageType)
        {
            var jsonContent = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(stageType),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PostAsync($"{apiBaseUrl}/stagetypes", jsonContent);
        }

        public async Task<HttpResponseMessage> UpdateStageTypeAsync(Guid StageId, StageTypeDTO updatedStageType)
        {
            var jsonContent = new StringContent(
                Newtonsoft.Json.JsonConvert.SerializeObject(updatedStageType),
                Encoding.UTF8,
                "application/json");

            return await httpClient.PutAsync($"{apiBaseUrl}/stagetypes/{StageId}", jsonContent);
        }

        public async Task<HttpResponseMessage> DeleteStageTypeAsync(Guid StageId)
        {
            return await httpClient.DeleteAsync($"{apiBaseUrl}/stagetypes/{StageId}");
        }
    }
}
