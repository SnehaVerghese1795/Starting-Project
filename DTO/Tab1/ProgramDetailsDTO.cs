using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam.DTO.Tab1
{
    public class ProgramDetailsDTO
    {
        private string programTitle { get; set; }
        private string programSummary { get; set; }
        private string programDescription { get; set; }
        private string programKeySkills { get; set; }
        private string programBenefits { get; set; }
        private string applicationCriteria { get; set; }
        public List<AdditionalInformationDTO> additionalInformation { get; set; }

        public string ProgramTitle
        {
            get { return programTitle; }
            set
            {
                if (value.Length > 100)
                {
                    Console.WriteLine("Program Title is too long.");
                }

                // Program Title should contain contains alphanumeric characters and spaces
                if (!Regex.IsMatch(value, "^[a-zA-Z0-9 ]+$"))
                {
                    Console.WriteLine("Program Title contains invalid characters.");
                }

                programTitle = value;
            }
        }

        public string ProgramSummary
        {
            get { return programSummary; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 10)
                {
                    Console.WriteLine("Program Summary must be at least 10 characters long.");
                }

                if (value.Length > 500)
                {
                    Console.WriteLine("Program Summary cannot exceed 500 characters.");
                }

                programSummary = value;
            }
        }

        public string ProgramDescription
        {
            get { return programDescription; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Program Description cannot be empty.");
                }

                if (value.Length < 50)
                {
                    Console.WriteLine("Program Description must be at least 50 characters long.");
                }

                if (value.Length > 1000)
                {
                    Console.WriteLine("Program description cannot exceed 1000 characters.");
                }

                programDescription = value;
            }
        }

        public string ProgramKeySkills
        {
            get { return programKeySkills; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Key Skills are required for the Program.");
                }

                // Check if key skills are comma-separated
                var skillsArray = value.Split(',');
                if (skillsArray.Length < 1)
                {
                    Console.WriteLine("Key Skills must be separated by commas.");
                }

                programKeySkills = value;
            }
        }

        public string ProgramBenefits
        {
            get { return programBenefits; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Program Benefits are required for the program.");
                }

                // Check if benefits are separated by line breaks
                var benefitsArray = value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (benefitsArray.Length < 1)
                {
                    Console.WriteLine("Program Benefits must be listed with line breaks.");
                }

                programBenefits = value;
            }
        }

        public string ApplicationCriteria
        {
            get { return applicationCriteria; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Application Criteria are required for the Program.");
                }

                // Check if criteria are separated by line breaks
                var criteriaArray = value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (criteriaArray.Length < 1)
                {
                    Console.WriteLine("Application Criteria must be listed with line breaks.");
                }

                applicationCriteria = value;
            }
        }
    }
}
