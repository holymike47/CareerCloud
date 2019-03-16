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
    public class Company : ICompany
    {
        private CompanyDescriptionLogic companyDescriptionLogic;
        private CompanyJobDescriptionLogic companyJobDescriptionLogic;
        private CompanyJobEducationLogic companyJobEducationLogic;
        private CompanyJobLogic companyJobLogic;
        private CompanyJobSkillLogic companyJobSkillLogic;
        private CompanyLocationLogic companyLocationLogic;
        private CompanyProfileLogic companyProfileLogic;
        
        public Company()
        {
            companyDescriptionLogic = new CompanyDescriptionLogic(new EFGenericRepository<CompanyDescriptionPoco>(false));
            companyJobDescriptionLogic = new CompanyJobDescriptionLogic(new EFGenericRepository<CompanyJobDescriptionPoco>(false));
            companyJobEducationLogic = new CompanyJobEducationLogic(new EFGenericRepository<CompanyJobEducationPoco>(false));
            companyJobLogic = new CompanyJobLogic(new EFGenericRepository<CompanyJobPoco>(false));
            companyJobSkillLogic = new CompanyJobSkillLogic(new EFGenericRepository<CompanyJobSkillPoco>(false));
            companyLocationLogic = new CompanyLocationLogic(new EFGenericRepository<CompanyLocationPoco>(false));
            companyProfileLogic = new CompanyProfileLogic(new EFGenericRepository<CompanyProfilePoco>(false));
        }
        public void AddCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            companyDescriptionLogic.Add(pocos);
        }

        public List<CompanyDescriptionPoco> GetAllCompanyDescription()
        {
            return companyDescriptionLogic.GetAll();
        }

        public CompanyDescriptionPoco GetSingleCompanyDescription(string id)
        {
            return companyDescriptionLogic.Get(Guid.Parse(id));
        }

        public void RemoveCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            companyDescriptionLogic.Delete(pocos);
        }

        public void UpdateCompanyDescription(CompanyDescriptionPoco[] pocos)
        {
            companyDescriptionLogic.Update(pocos);
        }//

        //CompanyJobDescription
        public void AddCompanyJobDescription(CompanyJobDescriptionPoco[] pocos)
        {
            companyJobDescriptionLogic.Add(pocos);
        }
        public List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription()
        {
            return companyJobDescriptionLogic.GetAll();
        }
        public CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string id)
        {
            return companyJobDescriptionLogic.Get(Guid.Parse(id));
        }
        public void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] pocos)
        {
            companyJobDescriptionLogic.Delete(pocos);
        }
        public void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] pocos)
        {
            companyJobDescriptionLogic.Update(pocos);
        }//

        //CompanyJobEducation
        public void AddCompanyJobEducation(CompanyJobEducationPoco[] pocos)
        {
            companyJobEducationLogic.Add(pocos);
        }

        public List<CompanyJobEducationPoco> GetAllCompanyJobEducation()
        {
            return companyJobEducationLogic.GetAll();
        }

        public CompanyJobEducationPoco GetSingleCompanyJobEducation(string id)
        {
            return companyJobEducationLogic.Get(Guid.Parse(id));
        }

        public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] pocos)
        {
            companyJobEducationLogic.Delete(pocos);
        }

        public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] pocos)
        {
            companyJobEducationLogic.Update(pocos);
        }//
         //CompanyJob
        public void AddCompanyJob(CompanyJobPoco[] pocos)
        {
            companyJobLogic.Add(pocos);
        }
        public List<CompanyJobPoco> GetAllCompanyJob()
        {
            return companyJobLogic.GetAll();
        }
        public CompanyJobPoco GetSingleCompanyJob(string id)
        {
            return companyJobLogic.Get(Guid.Parse(id));
        }
        public void RemoveCompanyJob(CompanyJobPoco[] pocos)
        {
            companyJobLogic.Delete(pocos);
        }
        public void UpdateCompanyJob(CompanyJobPoco[] pocos)
        {
            companyJobLogic.Update(pocos);
        }//
        //CompanyJobSkill
        public void AddCompanyJobSkill(CompanyJobSkillPoco[] pocos)
        {
            companyJobSkillLogic.Add(pocos);
        }

        public List<CompanyJobSkillPoco> GetAllCompanyJobSkill()
        {
            return companyJobSkillLogic.GetAll();
        }

        public CompanyJobSkillPoco GetSingleCompanyJobSkill(string id)
        {
            return companyJobSkillLogic.Get(Guid.Parse(id));
        }

        public void RemoveCompanyJobSkill(CompanyJobSkillPoco[] pocos)
        {
            companyJobSkillLogic.Delete(pocos);
        }

        public void UpdateCompanyJobSkill(CompanyJobSkillPoco[] pocos)
        {
            companyJobSkillLogic.Update(pocos);
        }

        ////CompanyLocation
        public void AddCompanyLocation(CompanyLocationPoco[] pocos)
        {
            companyLocationLogic.Add(pocos);
        }

        public List<CompanyLocationPoco> GetAllCompanyLocation()
        {
            return companyLocationLogic.GetAll();
        }

        public CompanyLocationPoco GetSingleCompanyLocation(string id)
        {
            return companyLocationLogic.Get(Guid.Parse(id));
        }

        public void RemoveCompanyLocation(CompanyLocationPoco[] pocos)
        {
            companyLocationLogic.Delete(pocos);
        }

        public void UpdateCompanyLocation(CompanyLocationPoco[] pocos)
        {
            companyLocationLogic.Update(pocos);
        }

        //CompanyProfile
        public void AddCompanyProfile(CompanyProfilePoco[] pocos)
        {
            companyProfileLogic.Add(pocos);
        }

        public List<CompanyProfilePoco> GetAllCompanyProfile()
        {
            return companyProfileLogic.GetAll();
        }

        public CompanyProfilePoco GetSingleCompanyProfile(string id)
        {
            return companyProfileLogic.Get(Guid.Parse(id));
        }

        public void RemoveCompanyProfile(CompanyProfilePoco[] pocos)
        {
            companyProfileLogic.Delete(pocos);
        }

        public void UpdateCompanyProfile(CompanyProfilePoco[] pocos)
        {
            companyProfileLogic.Update(pocos);
        }
    }
}
