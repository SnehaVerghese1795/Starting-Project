using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DTO.Tab2
{
    public class QuestionsDTO
    {
        public enum QuestionType
        {
            Paragraph,
            ShortAnswers,
            YesNo,
            DropDown,
            MultipleChoice,
            Date,
            Number,
            FilePath,
            VideoFilePath
        }

        public Guid QuestionId { get; private set; }
        public QuestionType Type { get;  set; }
        public string QuestionText { get;  set; }

        public QuestionsDTO(QuestionType type, string questionText)
        {
            Type = type;
            QuestionText = questionText;
        }

        public void AskQuestion()
        {
            Console.WriteLine(QuestionText);

            // To handle user input based on the question type
            switch (Type)
            {
                case QuestionType.Paragraph:
                case QuestionType.ShortAnswers:
                case QuestionType.YesNo:
                case QuestionType.FilePath:
                case QuestionType.VideoFilePath:
                    string userInput = Console.ReadLine();
                    Console.WriteLine($"User input: {userInput}");
                    break;
                case QuestionType.DropDown:
                    Console.WriteLine("Options: 1. Option A, 2. Option B, 3. Option C");
                    Console.Write("Select an option (1, 2, or 3): ");
                    string dropdownInput = Console.ReadLine();
                    int selectedOption;
                    if (int.TryParse(dropdownInput, out selectedOption) && selectedOption >= 1 && selectedOption <= 3)
                    {
                        Console.WriteLine($"User selected option: {selectedOption}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please select a valid option.");
                    }
                    break;
                case QuestionType.MultipleChoice:
                    Console.WriteLine("Options: A. Choice A, B. Choice B, C. Choice C");
                    Console.Write("Select an option (A, B, or C): ");
                    string multipleChoiceInput = Console.ReadLine();
                    char selectedChoice;
                    if (char.TryParse(multipleChoiceInput, out selectedChoice) &&
                        (selectedChoice == 'A' || selectedChoice == 'B' || selectedChoice == 'C'))
                    {
                        Console.WriteLine($"User selected choice: {selectedChoice}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please select a valid choice.");
                    }
                    break;
                case QuestionType.Date:
                    Console.WriteLine("Please enter a date (e.g., yyyy-mm-dd):");
                    string dateInput = Console.ReadLine();
                    DateTime date;
                    if (DateTime.TryParse(dateInput, out date))
                    {
                        Console.WriteLine($"User input: {date.ToString("yyyy-MM-dd")}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid date format. Please enter a valid date.");
                    }
                    break;
                case QuestionType.Number:
                    Console.WriteLine("Please enter a number:");
                    string numberInput = Console.ReadLine();
                    int number;
                    if (int.TryParse(numberInput, out number))
                    {
                        Console.WriteLine($"User input: {number}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Question Type.");
                    break;
            }
        }
    }
}
