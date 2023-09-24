using Exam.DTO.Tab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exam.Models.Tab2_Models
{
    public class AdditionalQuestions
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiBaseUrl = "http://your-api-base-url.com/";

        public async Task CreateAdditionalQuestion()
        {
            var newQuestion = new AdditionalQuestionsDTO
            {
                Paragraph = Console.ReadLine(),
                yearOfGraduation = GetDropDownFromUserInput(),
                Questions = Console.ReadLine(),
                Choice = Console.ReadLine(),
                YesNoQuestions = Console.ReadLine()
            };

            Console.WriteLine("You entered the following Additional Question Details:");
            Console.WriteLine($"Paragraph: {newQuestion.Paragraph}");
            Console.WriteLine($"Dropdown: {newQuestion.yearOfGraduation}");
            Console.WriteLine($"Questions: {newQuestion.Questions}");
            Console.WriteLine($"Choice: {newQuestion.Choice}");
            Console.WriteLine($"Yes/No Questions: {newQuestion.YesNoQuestions}");

            var postResponse = await PostAsync($"{apiBaseUrl}/additionalquestions", newQuestion);

            if (postResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Additional question created successfully.");

                await ReadAndUpdateAdditionalQuestion("New Additional Question");
            }
            else
            {
                Console.WriteLine("Failed to create the additional question.");
            }
        }

        protected async Task ReadAndUpdateAdditionalQuestion(string paragraph)
        {
            var question = await GetAdditionalQuestionAsync(paragraph);

            if (question != null)
            {
                Console.WriteLine($"Paragraph: {question.Paragraph}");
                Console.WriteLine($"Dropdown: {question.yearOfGraduation}");
                Console.WriteLine($"Questions: {question.Questions}");
                Console.WriteLine($"Choice: {question.Choice}");
                Console.WriteLine($"Yes/No Questions: {question.YesNoQuestions}");

                question.Paragraph = "Updated paragraph";

                var putResponse = await PutAsync($"{apiBaseUrl}/additionalquestions/{paragraph}", question);

                if (putResponse.IsSuccessStatusCode)
                {
                    Console.WriteLine("Additional question updated successfully.");

                    var deleteResponse = await DeleteAsync($"{apiBaseUrl}/additionalquestions/{paragraph}");

                    if (deleteResponse.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Additional question deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to delete the additional question.");
                    }
                }
                else
                {
                    Console.WriteLine("Failed to update the additional question.");
                }
            }
            else
            {
                Console.WriteLine("Failed to read the additional question.");
            }
        }

        protected async Task<AdditionalQuestionsDTO> GetAdditionalQuestionAsync(string paragraph)
        {
            var getResponse = await httpClient.GetAsync($"{apiBaseUrl}/additionalquestions/{paragraph}");

            if (getResponse.IsSuccessStatusCode)
            {
                var questionJson = await getResponse.Content.ReadAsStringAsync();
                return Newtonsoft.Json.JsonConvert.DeserializeObject<AdditionalQuestionsDTO>(questionJson);
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

        private AdditionalQuestionsDTO.DropDown GetDropDownFromUserInput()
        {
            Console.WriteLine("Select an option (1 for Year2016, 2 for Year2017, 3 for Year2018, 4 for Year2019, 5 for Year2020, 6 for Year2021, 7 for Year2022, 8 for Year2023):");

            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                switch (userInput)
                {
                    case 1:
                        return AdditionalQuestionsDTO.DropDown.Year2016;
                    case 2:
                        return AdditionalQuestionsDTO.DropDown.Year2017;
                    case 3:
                        return AdditionalQuestionsDTO.DropDown.Year2018;
                    case 4:
                        return AdditionalQuestionsDTO.DropDown.Year2019;
                    case 5:
                        return AdditionalQuestionsDTO.DropDown.Year2020;
                    case 6:
                        return AdditionalQuestionsDTO.DropDown.Year2021;
                    case 7:
                        return AdditionalQuestionsDTO.DropDown.Year2022;
                    case 8:
                        return AdditionalQuestionsDTO.DropDown.Year2023;
                    default:
                        Console.WriteLine("Invalid input. Defaulting to Option1.");
                        return AdditionalQuestionsDTO.DropDown.OptionInvalid;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Defaulting to Option1.");
                return AdditionalQuestionsDTO.DropDown.OptionInvalid;
            }
        }
    }
}

