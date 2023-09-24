using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.DTO.Tab1;
using Microsoft.Azure.Cosmos;



namespace Exam.Models.Tab1_Models
{
    public class ProgramDetailsRepository
    {
        private List<ProgramDetailsDTO> programDetailsList;

        public ProgramDetailsRepository()
        {
            programDetailsList = new List<ProgramDetailsDTO>();
        }

        public void AddProgram(ProgramDetailsDTO program)
        {
            programDetailsList.Add(program);
        }

        public ProgramDetailsDTO GetProgram(string programTitle)
        {
            return programDetailsList.FirstOrDefault(p => p.ProgramTitle.Equals(programTitle, StringComparison.OrdinalIgnoreCase));
        }

        public List<ProgramDetailsDTO> GetAllPrograms()
        {
            return programDetailsList;
        }

        public void UpdateProgram(ProgramDetailsDTO updatedProgram)
        {
            var existingProgram = programDetailsList.FirstOrDefault(p => p.ProgramTitle.Equals(updatedProgram.ProgramTitle, StringComparison.OrdinalIgnoreCase));

            if (existingProgram != null)
            {
                existingProgram.ProgramSummary = updatedProgram.ProgramSummary;
                existingProgram.ProgramDescription = updatedProgram.ProgramDescription;
                existingProgram.ProgramKeySkills = updatedProgram.ProgramKeySkills;
                existingProgram.ProgramBenefits = updatedProgram.ProgramBenefits;
                existingProgram.ApplicationCriteria = updatedProgram.ApplicationCriteria;
            }
        }

        public void DeleteProgram(string programTitle)
        {
            var programToDelete = programDetailsList.FirstOrDefault(p => p.ProgramTitle.Equals(programTitle, StringComparison.OrdinalIgnoreCase));

            if (programToDelete != null)
            {
                programDetailsList.Remove(programToDelete);
            }
        }
    }
}
