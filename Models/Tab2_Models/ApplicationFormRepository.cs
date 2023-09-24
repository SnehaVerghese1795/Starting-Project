using Exam.DTO.Tab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab2_Models
{
    public class ApplicationFormRepository
    {
        private List<ApplicationFormDTO> applicationFormsList = new List<ApplicationFormDTO>();

        public void AddApplicationForm(ApplicationFormDTO applicationForm)
        {
            applicationFormsList.Add(applicationForm);
        }

        public List<ApplicationFormDTO> GetAllApplicationForms()
        {
            return applicationFormsList;
        }

        public ApplicationFormDTO GetApplicationFormByImageUrl(Guid Id)
        {
            return applicationFormsList.FirstOrDefault(q => q.Id == Id);
        }

        public bool UpdateApplicationForm(Guid Id, ApplicationFormDTO updatedForm)
        {
            var formToUpdate = applicationFormsList.FirstOrDefault(a => a.Id == Id);

            if (formToUpdate != null)
            {
                formToUpdate.ImageUrl = updatedForm.ImageUrl;
                formToUpdate.PersonalInformation = updatedForm.PersonalInformation;
                formToUpdate.Profile = updatedForm.Profile;
                formToUpdate.AdditionalQuestions = updatedForm.AdditionalQuestions;
                return true;
            }

            return false;
        }
    }
}
