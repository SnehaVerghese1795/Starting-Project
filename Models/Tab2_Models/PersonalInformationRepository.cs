using Exam.DTO.Tab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab2_Models
{
    public class PersonalInformationRepository
    {
        private List<PersonalInformationDTO> personalInformationList;

        public PersonalInformationRepository()
        {
            personalInformationList = new List<PersonalInformationDTO>();
        }

        public void AddPersonalInformation(PersonalInformationDTO personalInfo)
        {
            personalInformationList.Add(personalInfo);
        }

        public PersonalInformationDTO GetPersonalInformation(int idNumber)
        {
            return personalInformationList.FirstOrDefault(p => p.IdNumber == idNumber);
        }

        public List<PersonalInformationDTO> GetAllPersonalInformation()
        {
            return personalInformationList;
        }

        public void UpdatePersonalInformation(int idNumber, PersonalInformationDTO updatedInfo)
        {
            var existingInfo = personalInformationList.FirstOrDefault(p => p.IdNumber == idNumber);

            if (existingInfo != null)
            {
                existingInfo.FirstName = updatedInfo.FirstName;
                existingInfo.LastName = updatedInfo.LastName;
                existingInfo.Email = updatedInfo.Email;
                existingInfo.Phone = updatedInfo.Phone;
                existingInfo.Nationality = updatedInfo.Nationality;
                existingInfo.CurrentResidence = updatedInfo.CurrentResidence;
                existingInfo.DateOfBirth = updatedInfo.DateOfBirth;
                existingInfo.Gender = updatedInfo.Gender;
            }
        }

        public void DeletePersonalInformation(int idNumber)
        {
            var infoToDelete = personalInformationList.FirstOrDefault(p => p.IdNumber == idNumber);

            if (infoToDelete != null)
            {
                personalInformationList.Remove(infoToDelete);
            }
        }
    }
}
