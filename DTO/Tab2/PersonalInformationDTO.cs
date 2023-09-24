using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam.DTO.Tab2
{
    public class PersonalInformationDTO
    {
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string eMail { get; set; }
        private int phone { get; set; }
        private string nationality { get; set; }
        private string currentResidence { get; set; }
        private int idNumber { get; set; }
        private DateTime dateOfBirth { get; set; }
        private string gender { get; set; }
        private List<QuestionsDTO> questions { get; set; }
        
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    firstName = value;
                }
                else
                {
                    Console.WriteLine("First Name cannot be empty.");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    lastName = value;
                }
                else
                {
                    Console.WriteLine("Last Name cannot be empty.");
                }
            }
        }

        public string Email
        {
            get { return eMail; }
            set
            {
                if (IsValidEmail(value))
                {
                    eMail = value;
                }
                else
                {
                    Console.WriteLine("Invalid email address.");
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            // Split the email address into local part and domain part
            string[] parts = email.Split('@');

            if (parts.Length != 2)
            {
                return false; 
            }

            string localPart = parts[0];
            string domainPart = parts[1];

            if (localPart.Length > 64)
            {
                Console.WriteLine("Invalid Email Address");
                return false;
            }

            if (domainPart.Length > 255)
            {
                return false;
            }

            if (!domainPart.Contains("."))
            {
                return false;
            }

            return true;
        }

        public int Phone
        {
            get { return phone; }
            set
            {
                if (IsValidPhoneNumber(value))
                {
                    phone = value;
                }
                else
                {
                    Console.WriteLine("Invalid Phone Number.");
                }
            }
        }

        private bool IsValidPhoneNumber(int phoneNumber)
        {
            string phoneNumberStr = phoneNumber.ToString();

            if (string.IsNullOrEmpty(phoneNumberStr))
            {
                return false;
            }

            // Define a regular expression pattern for a 10-digit US phone number
            string pattern = @"^\d{10}$";

            if (!Regex.IsMatch(phoneNumberStr, pattern))
            {
                return false;
            }

            return true;
        }

        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        public string CurrentResidence
        {
            get { return currentResidence; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Address cannot be null.");
                }
                else if (value.Trim() == "")
                {
                    Console.WriteLine("Address cannot be empty.");
                }
                else if (value.Length > 200)
                {
                    Console.WriteLine("Address is too long.");
                }
                else
                {
                    currentResidence = value;
                }
            }
        }

        public int IdNumber
        {
            get { return idNumber; }
            set
            {
                if (value >= 0 && value <= 1000)
                {
                    idNumber = value;
                }
                else
                {
                    Console.WriteLine("ID must be between 0 and 1000.");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                // Assuming 18 years as the minimum age for an undergraduate graduate
                DateTime currentDate = DateTime.Now;
                DateTime minimumDate = currentDate.AddYears(-18); 

                if (value <= minimumDate)
                {
                    dateOfBirth = value;
                }
                else
                {
                    Console.WriteLine("Invalid Date Of Birth");
                }
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                string input = value.Trim().ToLower();
                if (input == "male" || input == "female")
                {
                    gender = input;
                }
                else
                {
                    Console.WriteLine("Invalid Gender input.");
                }
            }
        }

        public List<QuestionsDTO> Questions
        {
            get { return questions; }
            internal set { questions = value; }
        }
    }
}

