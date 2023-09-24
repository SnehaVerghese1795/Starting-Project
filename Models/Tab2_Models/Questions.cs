using Exam.DTO.Tab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace Exam.Models.Tab2_Models
{
    public class Questions
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiBaseUrl = "http://your-api-base-url.com/";

        public async Task CreateQuestion()
        {
            var newQuestion = new QuestionsDTO(GetQuestionTypeFromUserInput(), Console.ReadLine())
            {
                Type = GetQuestionTypeFromUserInput(),
                QuestionText = Console.ReadLine(),
            };

            Console.WriteLine("You entered the following Question Details:");
            Console.WriteLine($"Type: {newQuestion.Type}");
            Console.WriteLine($"Question Text: {newQuestion.QuestionText}");

            var postResponse = await PostAsync($"{apiBaseUrl}/questions", newQuestion);

            if (postResponse.IsSuccessStatusCode)
            {
                var createdQuestion = await postResponse.Content.ReadFromJsonAsync<QuestionsDTO>();
                Console.WriteLine($"Question created successfully with ID: {createdQuestion.QuestionId}");

                await ReadAndUpdateQuestion(createdQuestion.QuestionId);
            }
            else
            {
                Console.WriteLine("Failed to create the question.");
            }
        }

        public async Task ReadAndUpdateQuestion(Guid QuestionId)
        {
            var question = await GetQuestionAsync(QuestionId);

            if (question != null)
            {
                Console.WriteLine($"Type: {question.Type}");
                Console.WriteLine($"Question Text: {question.QuestionText}");

                question.QuestionText = "Updated question text";

                var putResponse = await PutAsync($"{apiBaseUrl}/questions/{QuestionId}", question);

                if (putResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Question updated successfully.");

                    var deleteResponse = await DeleteAsync($"{apiBaseUrl}/questions/{QuestionId}");

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Question deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to delete the question.");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to update the question.");
                }
            }
            else
            {
                Console.WriteLine("Failed to read the question.");
            }
        }

        public async Task<QuestionsDTO> GetQuestionAsync(Guid questionId)
        {
            var getResponse = await httpClient.GetAsync($"{apiBaseUrl}/questions/{questionId}");

            if (getResponse.IsSuccessStatusCode)
            {
                var questionJson = await getResponse.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<QuestionsDTO>(questionJson);
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

        private static QuestionsDTO.QuestionType GetQuestionTypeFromUserInput()
        {
            Console.WriteLine("Enter Question Type :");
            if (Enum.TryParse<QuestionsDTO.QuestionType>(Console.ReadLine(), out QuestionsDTO.QuestionType type))
            {
                return type;
            }
            else
            {
                Console.WriteLine("Invalid Question Type. Defaulting to MultipleChoice.");
                return QuestionsDTO.QuestionType.MultipleChoice;
            }
        }
    }
}
