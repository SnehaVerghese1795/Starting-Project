using Exam.DTO.Tab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab2_Models
{
    public class QuestionsRepository
    {
        private List<QuestionsDTO> questionsList;

        public QuestionsRepository()
        {
            questionsList = new List<QuestionsDTO>();
        }

        public void AddQuestion(QuestionsDTO question)
        {
            questionsList.Add(question);
        }

        public QuestionsDTO GetQuestion(Guid QuestionId)
        {
            return questionsList.FirstOrDefault(q => q.QuestionId == QuestionId);
        }

        public List<QuestionsDTO> GetAllQuestions()
        {
            return questionsList;
        }

        public void UpdateQuestion(QuestionsDTO updatedQuestion)
        {
            var existingQuestion = questionsList.FirstOrDefault(q => q.QuestionId == updatedQuestion.QuestionId);

            if (existingQuestion != null)
            {
                existingQuestion.Type = updatedQuestion.Type;
                existingQuestion.QuestionText = updatedQuestion.QuestionText;
            }
        }

        public void DeleteQuestion(Guid QuestionId)
        {
            var questionToDelete = questionsList.FirstOrDefault(q => q.QuestionId == QuestionId);

            if (questionToDelete != null)
            {
                questionsList.Remove(questionToDelete);
            }
        }
    }
}
