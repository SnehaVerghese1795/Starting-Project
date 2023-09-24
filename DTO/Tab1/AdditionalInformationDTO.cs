using Exam.Models.Tab1_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DTO.Tab1
{
    public class AdditionalInformationDTO
    {
        private string programType { get; set; }
        private DateTime programStart { get; set; }
        private DateTime applicationOpen { get; set; }
        private DateTime applicationClose { get; set; }
        private string duration { get; set; }
        private string programLocation { get; set; }
        private string minQualifications { get; set; }
        private int maxNoOfApplication { get; set;}
        public ProgramDetails programDetails { get; set; }

        public string ProgramType
        {
            get { return programType; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Program Type is required.");
                }

                programType = value;
            }
        }

        public DateTime ProgramStart
        {
            get { return programStart; }
            set
            {
                if (value == DateTime.MinValue)
                {
                    Console.WriteLine("Program Start date is required.");
                }

                if (value < DateTime.Now)
                {
                    Console.WriteLine("Program Start date must be in the future.");
                }

                var maxAllowedDate = DateTime.Now.AddYears(1);
                if (value > maxAllowedDate)
                {
                    Console.WriteLine($"Program Start date cannot exceed {maxAllowedDate.ToShortDateString()}");
                }

                programStart = value;
            }
        }

        public DateTime ApplicationOpen
        {
            get { return applicationOpen; }
            set
            {
                if (value == DateTime.MinValue)
                {
                    Console.WriteLine("Application Open date is required.");
                }

                if (value < DateTime.Now)
                {
                    Console.WriteLine("Application Open date must be in the future.");
                }

                // Ensure that ApplicationOpen is before ApplicationClose
                if (ApplicationClose != DateTime.MinValue && value >= ApplicationClose)
                {
                    Console.WriteLine("Application Open date must be before the application close date.");
                }

                applicationOpen = value;
            }
        }

        public DateTime ApplicationClose
        {
            get { return applicationClose; }
            set
            {
                if (value == DateTime.MinValue || value < DateTime.Now)
                {
                    Console.WriteLine("Invalid Application Close date.");
                }

                if (value <= ProgramStart)
                {
                    Console.WriteLine("Application Close date must be after the Program Start date.");
                }

                applicationClose = value;
            }
        }

        public string Duration
        {
            get { return duration; }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Duration is required.");
                }

                if (!IsValidDuration(value))
                {
                    Console.WriteLine("Invalid Duration format.");
                }

                duration = value;
            }
        }

        public bool IsValidDuration(string value)
        {
            
            if (int.TryParse(value, out int numericValue))
            {
                
                if (numericValue > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public string ProgramLocation
        {
            get { return programLocation; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Program Location is required.");
                }

                if (value.Length > 50)
                {
                    Console.WriteLine("Program Location cannot exceed 50 characters.");
                }

                programLocation = value;
            }
        }

        private static readonly string[] ValidQualifications = { "High School", "Graduate" };

        private bool IsValidQualifications(string value)
        {
            // Check if the selected value is one of the valid options
            return ValidQualifications.Contains(value);
        }

        public string MinQualifications
        {
            get { return minQualifications; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Minimum Qualification is required.");
                }

                if (!IsValidQualifications(value))
                {
                    Console.WriteLine("Invalid Minimum Qualification selected.");
                }

                minQualifications = value;
            }
        }        

        public int MaxNoOfApplication
        {
            get { return maxNoOfApplication; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Maximum Number of Applications cannot be negative.");
                }

                if (value > 1000)
                {
                    Console.WriteLine("Maximum Number of Applications exceeds the allowed limit.");
                }

                maxNoOfApplication = value;
            }
        }
    }
}
