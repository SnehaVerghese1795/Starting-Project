using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DTO.Tab2
{
    public class ProfileDTO
    {
        public Guid ProfileId { get; private set; }
        private SlideButton education { get; set; }
        private SlideButton experience { get; set; }
        private string resumePath { get; set; }

        public ProfileDTO()
        {
            education = new SlideButton();
            experience = new SlideButton();
        }

        public SlideButton Education
        {
            get { return education; }
            set { education = value; }
        }

        public SlideButton Experience
        {
            get { return experience; }
            set { experience = value; }
        }

        public string ResumePath
        {
            get { return resumePath; }
            set 
            {
                if (File.Exists(value))
                {
                    resumePath = value;
                    Console.WriteLine("Resume uploaded successfully.");
                }
                else
                {
                    Console.WriteLine("File does not exist. Resume upload failed.");
                }
            }
        }
    }

    public class SlideButton
    {
        private bool isVisible { get; set; }
        public EducationData educationdata { get; set; }
        public ExperienceData experiencedata { get; set; }

        public SlideButton()
        {
            isVisible = bool.Parse(Console.ReadLine());
            educationdata = new EducationData();
            experiencedata = new ExperienceData();
        }

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
    }

    public class EducationData
    {
        private string school { get; set; }
        public Degree degree { get; set; }
        private string courseName { get; set; }
        public SchoolLocation schoolLocation { get; set; }
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }

        public enum Degree
        {
            Bachelor,
            Master,
            PhD,
            Other
        }

        public enum SchoolLocation
        {
            Local,
            Remote,
            International
        }

        public string School
        {
            get { return school; }
            set { school = value; }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value != null)
                {
                    if (value <= endDate)
                    {
                        startDate = value;
                    }
                    else
                    {
                        Console.WriteLine("Start Date cannot be greater than End Date.");
                    }
                }
                else
                {
                    Console.WriteLine("Start Date cannot be null.");
                }
            }

        }
               
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value != null)
                {
                    if (value >= startDate)
                    {
                        endDate = value;
                    }
                    else
                    {
                        Console.WriteLine("End Date cannot be less than Start Date.");
                    }
                }
                else
                {
                    Console.WriteLine("End Date cannot be null.");
                }
            }
        }
    }

    public class ExperienceData
    {
        private string company { get; set; }
        private string title { get; set; }
        public WorkLocation workLocation { get; set; }
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }

        public enum WorkLocation
        {
            Office,
            Remote,
            OnSite
        }
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value != null)
                {
                    if (value <= endDate)
                    {
                        startDate = value;
                    }
                    else
                    {
                        Console.WriteLine("Start Date cannot be greater than End Date.");
                    }
                }
                else
                {
                    Console.WriteLine("Start Date cannot be null.");
                }
            }

        }

        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                if (value != null)
                {
                    if (value >= startDate)
                    {
                        endDate = value;
                    }
                    else
                    {
                        Console.WriteLine("End Date cannot be less than Start Date.");
                    }
                }
                else
                {
                    Console.WriteLine("End Date cannot be null.");
                }
            }
        }
    }

    
}

