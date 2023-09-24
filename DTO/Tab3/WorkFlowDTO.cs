using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DTO.Tab3
{
    public class WorkFlowDTO
    {
        public Guid workFlowId { get; set; }

        public List<string> panel = new List<string>() { "Applied", "Shortlisted", "Video Interview", "1st Round Zoom Interview", "In-person meeting", "Placement", "Offered" };

        private string stageName { get; set; }
        private List<StageTypeDTO> stageType { get; set; }

        public string StageName
        {
            get { return stageName; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Length <= 50)
                    {
                        stageName = value;
                    }
                    else
                    {
                        Console.WriteLine("Stage name is too long.");
                    }

                }
                else
                {
                    Console.WriteLine("Stage name field is empty.");
                }
            }
        }

        public List<StageTypeDTO> StageType 
        {
            get { return stageType; }
            internal set { stageType = value; }
        }
    }
}
