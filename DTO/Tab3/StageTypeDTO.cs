using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.DTO.Tab3
{
    public class StageTypeDTO
    {
        public Guid StageId { get; private set; }
        private string shortListing { get; set; }
        public VideoInterview videoInterview { get; set; }
        private string placement { get; set; }

        public string ShortListing
        {
            get { return shortListing; }
            set { shortListing = value; }
        }

        public string Placement
        {
            get { return placement; }
            set { placement = value; }
        }

        public enum VideoInterview
        {
            VideoInterviewQuestion,
            Recommendations,
            VideoDuration,
            NoOfDays
        }
    }    

}
