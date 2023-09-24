using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DTO.Tab2
{
    public class AdditionalQuestionsDTO
    {
        public Guid AddQuestId { get; set; }
        private string paragraph { get; set; }
        public DropDown yearOfGraduation { get; set; }
        private string questions { get; set; }
        private string choice { get; set; }
        private string yesNoQuestions { get; set; }

        public enum DropDown
        {
            Year2016,
            Year2017,
            Year2018,
            Year2019,
            Year2020,
            Year2021,
            Year2022,
            Year2023,
            OptionInvalid
        }

        public string Paragraph
        {
            get { return paragraph; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length <= 100)
                    {
                        paragraph = value;
                    }
                    else
                    {
                        Console.WriteLine("Paragraph is too long.");
                    }

                }
                else
                {
                    Console.WriteLine("Paragraph field is empty.");
                }
            }
        }

        public string Questions
        {
            get { return questions; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length <= 100)
                    {
                        questions = value;
                    }
                    else
                    {
                        Console.WriteLine("Question entered is too long.");
                    }

                }
                else
                {
                    Console.WriteLine("Question field is empty.");
                }
            }
        }

        public string Choice
        {
            get { return choice; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length <= 50)
                    {
                        choice = value;
                    }
                    else
                    {
                        Console.WriteLine("Choice entered is too long.");
                    }

                }
                else
                {
                    Console.WriteLine("Choice field is empty.");
                }
            }
        }

        public string YesNoQuestions
        {
            get { return yesNoQuestions; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length <= 100)
                    {
                        yesNoQuestions = value;
                    }
                    else
                    {
                        Console.WriteLine("Question entered is too long.");
                    }

                }
                else
                {
                    Console.WriteLine("Yes/No Question field is empty.");
                }
            }
        }

    }
}
