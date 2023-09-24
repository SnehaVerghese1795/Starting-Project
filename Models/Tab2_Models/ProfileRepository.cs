using Exam.DTO.Tab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Tab2_Models
{
    public class ProfileRepository
    {
        private List<ProfileDTO> profileList;

        public ProfileRepository()
        {
            profileList = new List<ProfileDTO>();
        }

        public void AddProfile(ProfileDTO profile)
        {
            profileList.Add(profile);
        }

        public ProfileDTO GetProfile(Guid ProfileId)
        {
            return profileList.FirstOrDefault(p => p.ProfileId == ProfileId);
        }

        public List<ProfileDTO> GetAllProfiles()
        {
            return profileList;
        }

        public void UpdateProfile(ProfileDTO updatedProfile)
        {
            var existingProfile = profileList.FirstOrDefault(p => p.ProfileId == updatedProfile.ProfileId);

            if (existingProfile != null)
            {
                existingProfile.Education = updatedProfile.Education;
                existingProfile.Experience = updatedProfile.Experience;
                existingProfile.ResumePath = updatedProfile.ResumePath;
            }
        }

        public void DeleteProfile(Guid ProfileId)
        {
            var profileToDelete = profileList.FirstOrDefault(p => p.ProfileId == ProfileId);

            if (profileToDelete != null)
            {
                profileList.Remove(profileToDelete);
            }
        }
    }
}
