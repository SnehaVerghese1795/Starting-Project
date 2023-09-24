using Exam.DTO.Tab3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab3
{
    public class WorkFlow
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiBaseUrl = "http://your-api-base-url.com/";

        private List<WorkFlowDTO> workflows = new List<WorkFlowDTO>();


        public async Task CreateWorkFlowAsync(WorkFlowDTO workflow)
        {
            var workflowJson = JsonConvert.SerializeObject(workflow);
            var content = new StringContent(workflowJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync($"{apiBaseUrl}/workflows", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task<WorkFlowDTO> GetWorkFlowAsync(Guid workFlowId)
        {
            var response = await httpClient.GetAsync($"{apiBaseUrl}/workflows/{workFlowId}");

            if (response.IsSuccessStatusCode)
            {
                var workflowJson = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WorkFlowDTO>(workflowJson);
            }
            return null;
        }

        public async Task UpdateWorkFlowAsync(Guid workFlowId, WorkFlowDTO updatedWorkflow)
        {
            var workflowJson = JsonConvert.SerializeObject(updatedWorkflow);
            var content = new StringContent(workflowJson, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync($"{apiBaseUrl}/workflows/{workFlowId}", content);

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteWorkFlowAsync(Guid workFlowId)
        {
            var response = await httpClient.DeleteAsync($"{apiBaseUrl}/workflows/{workFlowId}");

            response.EnsureSuccessStatusCode();
        }
    }
}
