using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.ADODataAccessLayer;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{

    public class Applicant : IApplicant
    {
        private ApplicantEducationLogic applicantEducationLogic;
        private ApplicantJobApplicationLogic applicantJobApplicationLogic;
        private ApplicantProfileLogic applicantProfileLogic;
        private ApplicantResumeLogic applicantResumeLogic;
        private ApplicantSkillLogic applicantSkillLogic;
        private ApplicantWorkHistoryLogic applicantWorkHistoryLogic;


        public Applicant()
        {
         
            applicantEducationLogic = new ApplicantEducationLogic(new EFGenericRepository<ApplicantEducationPoco>(false));
            applicantJobApplicationLogic = new ApplicantJobApplicationLogic(new EFGenericRepository<ApplicantJobApplicationPoco>(false));
            applicantProfileLogic = new ApplicantProfileLogic(new EFGenericRepository<ApplicantProfilePoco>(false));
            applicantResumeLogic = new ApplicantResumeLogic(new EFGenericRepository<ApplicantResumePoco>(false));
            applicantSkillLogic = new ApplicantSkillLogic(new EFGenericRepository<ApplicantSkillPoco>(false));
            applicantWorkHistoryLogic = new ApplicantWorkHistoryLogic(new EFGenericRepository<ApplicantWorkHistoryPoco>(false));
        }


        //ApplicantEducation
        public void AddApplicantEducation(ApplicantEducationPoco[] pocos)
        {
            applicantEducationLogic.Add(pocos);
        }

        public List<ApplicantEducationPoco> GetAllApplicantEducation()
        {
            return applicantEducationLogic.GetAll();
        }

        public ApplicantEducationPoco GetSingleApplicantEducation(string id)
        {
            return applicantEducationLogic.Get(Guid.Parse(id));
        }

        public void RemoveApplicantEducation(ApplicantEducationPoco[] pocos)
        {
            applicantEducationLogic.Delete(pocos);
        }

        public void UpdateApplicantEducation(ApplicantEducationPoco[] pocos)
        {
            applicantEducationLogic.Update(pocos);
        }


        
                     //ApplicantJobApplication//

        public void AddApplicantJobApplication(ApplicantJobApplicationPoco[] pocos)
        {
            applicantJobApplicationLogic.Add(pocos);
        }
       
        public List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication()
        {
            return applicantJobApplicationLogic.GetAll();
        }
        
        public ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string id)
        {
            return applicantJobApplicationLogic.Get(Guid.Parse(id));
        }
        
        public void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] pocos)
        {
            applicantJobApplicationLogic.Delete(pocos);
        }
        
        public void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] pocos)
        {
            applicantJobApplicationLogic.Update(pocos);
        }


        //ApplicantProfile
        public void AddApplicantProfile(ApplicantProfilePoco[] pocos)
        {
            applicantProfileLogic.Add(pocos);
        }

        public List<ApplicantProfilePoco> GetAllApplicantProfile()
        {
            return applicantProfileLogic.GetAll();
        }

        public ApplicantProfilePoco GetSingleApplicantProfile(string id)
        {
            return applicantProfileLogic.Get(Guid.Parse(id));
        }

        public void RemoveApplicantProfile(ApplicantProfilePoco[] pocos)
        {
            applicantProfileLogic.Delete(pocos);
        }

        public void UpdateApplicantProfile(ApplicantProfilePoco[] pocos)
        {
            applicantProfileLogic.Update(pocos);
        }//

        // ApplicantResume
        public void AddApplicantResume(ApplicantResumePoco[] pocos)
        {
            applicantResumeLogic.Add(pocos);
        }

        public List<ApplicantResumePoco> GetAllApplicantResume()
        {
            return applicantResumeLogic.GetAll();
        }

        public ApplicantResumePoco GetSingleApplicantResume(string id)
        {
            return applicantResumeLogic.Get(Guid.Parse(id));
        }

        public void RemoveApplicantResume(ApplicantResumePoco[] pocos)
        {
            applicantResumeLogic.Delete(pocos);
        }

        public void UpdateApplicantResume(ApplicantResumePoco[] pocos)
        {
            applicantResumeLogic.Update(pocos);
        }//

        //ApplicantSkill
        public void AddApplicantSkill(ApplicantSkillPoco[] pocos)
        {
            applicantSkillLogic.Add(pocos);
        }

        public List<ApplicantSkillPoco> GetAllApplicantSkill()
        {
            return applicantSkillLogic.GetAll();
        }

        public ApplicantSkillPoco GetSingleApplicantSkill(string id)
        {
            return applicantSkillLogic.Get(Guid.Parse(id));
        }

        public void RemoveApplicantSkill(ApplicantSkillPoco[] pocos)
        {
            applicantSkillLogic.Delete(pocos);
        }

        public void UpdateApplicantSkill(ApplicantSkillPoco[] pocos)
        {
            applicantSkillLogic.Update(pocos);
        }//

        //ApplicantWorkHistory
        public void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos)
        {
            applicantWorkHistoryLogic.Add(pocos);
        }

        public List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory()
        {
            return applicantWorkHistoryLogic.GetAll();
        }

        public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string id)
        {
            return applicantWorkHistoryLogic.Get(Guid.Parse(id));
        }

        public void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos)
        {
            applicantWorkHistoryLogic.Delete(pocos);
        }

        public void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] pocos)
        {
            applicantWorkHistoryLogic.Update(pocos);
        }
    }
}
