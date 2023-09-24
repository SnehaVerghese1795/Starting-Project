using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DTO.Tab2
{
    public class ApplicationFormDTO
    {
        public Guid Id { get; private set; }
        private string imageUrl { get; set; }
        private List<PersonalInformationDTO> personalInformation { get; set; }
        private List<ProfileDTO> profile { get; set; }        
        private List<AdditionalQuestionsDTO> additionalQuestions { get; set; }

        public string ImageUrl 
        { 
            get { return imageUrl; } 
            set { imageUrl = value; } 
        }

        public List<PersonalInformationDTO> PersonalInformation 
        { 
            get { return personalInformation; } 
            set { personalInformation = value; } 
        }

        public List<ProfileDTO> Profile
        {
            get { return profile; }
            set { profile = value; }
        }

        public List<AdditionalQuestionsDTO> AdditionalQuestions
        {
            get { return additionalQuestions; }
            set { additionalQuestions = value; }
        }
    }
}
