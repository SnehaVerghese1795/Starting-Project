using Exam.DTO.Tab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab2_Models
{
    public class AdditionalQuestionsRepository
    {
        private List<AdditionalQuestionsDTO> additionalQuestionsList;

        public AdditionalQuestionsRepository()
        {
            additionalQuestionsList = new List<AdditionalQuestionsDTO>();
        }

        public void AddAdditionalQuestion(AdditionalQuestionsDTO question)
        {
            additionalQuestionsList.Add(question);
        }

        public AdditionalQuestionsDTO GetAdditionalQuestion(Guid AddQuestId)
        {
            return additionalQuestionsList.FirstOrDefault(q => q.AddQuestId == AddQuestId);
        }

        public List<AdditionalQuestionsDTO> GetAllAdditionalQuestions()
        {
            return additionalQuestionsList;
        }

        public void UpdateAdditionalQuestion(AdditionalQuestionsDTO updatedQuestion)
        {
            var existingQuestion = additionalQuestionsList.FirstOrDefault(q => q.AddQuestId == updatedQuestion.AddQuestId);

            if (existingQuestion != null)
            {
                existingQuestion.Paragraph = updatedQuestion.Paragraph;
                existingQuestion.yearOfGraduation = updatedQuestion.yearOfGraduation;
                existingQuestion.Questions = updatedQuestion.Questions;
                existingQuestion.Choice = updatedQuestion.Choice;
                existingQuestion.YesNoQuestions = updatedQuestion.YesNoQuestions;
            }
        }

        public void DeleteAdditionalQuestion(Guid AddQuestId)
        {
            var questionToDelete = additionalQuestionsList.FirstOrDefault(q => q.AddQuestId == AddQuestId);

            if (questionToDelete != null)
            {
                additionalQuestionsList.Remove(questionToDelete);
            }
        }
    }
}
