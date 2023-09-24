using Exam.DTO.Tab3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab3_Models
{
    public class StageTypeRepository
    {
        private List<StageTypeDTO> stageTypeList;

        public StageTypeRepository()
        {
            stageTypeList = new List<StageTypeDTO>();
        }

        public void AddStageType(StageTypeDTO stageType)
        {
            stageTypeList.Add(stageType);
        }

        public StageTypeDTO GetStageType(Guid StageId)
        {
            return stageTypeList.FirstOrDefault(s => s.StageId == StageId);
        }

        public List<StageTypeDTO> GetAllStageTypes()
        {
            return stageTypeList;
        }

        public void UpdateStageType(StageTypeDTO updatedStageType)
        {
            var existingStageType = stageTypeList.FirstOrDefault(s => s.StageId == updatedStageType.StageId);

            if (existingStageType != null)
            {
                existingStageType.ShortListing = updatedStageType.ShortListing;
                existingStageType.videoInterview = updatedStageType.videoInterview;
                existingStageType.Placement = updatedStageType.Placement;
            }
        }

        public void DeleteStageType(Guid StageId)
        {
            var stageTypeToDelete = stageTypeList.FirstOrDefault(s => s.StageId == StageId);

            if (stageTypeToDelete != null)
            {
                stageTypeList.Remove(stageTypeToDelete);
            }
        }
    }
}
