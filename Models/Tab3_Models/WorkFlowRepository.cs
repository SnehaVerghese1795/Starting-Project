using Exam.DTO.Tab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab3
{
    public class WorkFlowRepository
    {
        private List<WorkFlowDTO> workFlowsList;

        public WorkFlowRepository()
        {
            workFlowsList = new List<WorkFlowDTO>();
        }

        public void AddWorkFlow(WorkFlowDTO workFlow)
        {
            workFlowsList.Add(workFlow);
        }

        public WorkFlowDTO GetWorkFlow(Guid workFlowId)
        {
            return workFlowsList.FirstOrDefault(w => w.workFlowId == workFlowId);
        }

        public List<WorkFlowDTO> GetAllWorkFlows()
        {
            return workFlowsList;
        }

        public void UpdateWorkFlow(Guid workFlowId, WorkFlowDTO updatedWorkFlow)
        {
            var existingWorkFlow = workFlowsList.FirstOrDefault(w => w.workFlowId == workFlowId);

            if (existingWorkFlow != null)
            {
                existingWorkFlow.panel = updatedWorkFlow.panel;
                existingWorkFlow.StageName = updatedWorkFlow.StageName;
                existingWorkFlow.StageType = updatedWorkFlow.StageType;
            }
        }

        public void DeleteWorkFlow(Guid workFlowId)
        {
            var workFlowToDelete = workFlowsList.FirstOrDefault(w => w.workFlowId == workFlowId);

            if (workFlowToDelete != null)
            {
                workFlowsList.Remove(workFlowToDelete);
            }
        }
    }
}
