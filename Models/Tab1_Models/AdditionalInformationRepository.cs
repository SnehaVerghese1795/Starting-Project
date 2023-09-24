using Exam.DTO.Tab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab1_Models
{
    public class AdditionalInformationRepository
    {
        private List<AdditionalInformationDTO> additionalInformationList = new List<AdditionalInformationDTO>();

        public void AddAdditionalInformation(AdditionalInformationDTO additionalInformation)
        {
            additionalInformationList.Add(additionalInformation);
        }

        public List<AdditionalInformationDTO> GetAllAdditionalInformation()
        {
            return additionalInformationList;
        }

        public AdditionalInformationDTO GetAdditionalInformationByProgramType(string programType)
        {
            return additionalInformationList.FirstOrDefault(info => info.ProgramType.Equals(programType, StringComparison.OrdinalIgnoreCase));
        }

        public bool UpdateAdditionalInformation(string programType, AdditionalInformationDTO updatedInformation)
        {
            var informationToUpdate = GetAdditionalInformationByProgramType(programType);
            if (informationToUpdate != null)
            {
                informationToUpdate.ProgramStart = updatedInformation.ProgramStart;
                informationToUpdate.ApplicationOpen = updatedInformation.ApplicationOpen;
                informationToUpdate.ApplicationClose = updatedInformation.ApplicationClose;
                informationToUpdate.Duration = updatedInformation.Duration;
                informationToUpdate.ProgramLocation = updatedInformation.ProgramLocation;
                informationToUpdate.MinQualifications = updatedInformation.MinQualifications;
                informationToUpdate.MaxNoOfApplication = updatedInformation.MaxNoOfApplication;
                return true;
            }
            return false;
        }

        public bool DeleteAdditionalInformation(string programType)
        {
            var informationToRemove = GetAdditionalInformationByProgramType(programType);
            if (informationToRemove != null)
            {
                additionalInformationList.Remove(informationToRemove);
                return true;
            }
            return false;
        }
    }
}
