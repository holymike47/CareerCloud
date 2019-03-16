using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.ADODataAccessLayer;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    public class System : ISystem
    {
        private SystemCountryCodeLogic systemCountryCodeLogic;
        private SystemLanguageCodeLogic SystemLanguageCodeLogic;

        public System()
        {
            systemCountryCodeLogic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
            SystemLanguageCodeLogic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
        }
        public void AddSystemCountryCode(SystemCountryCodePoco[] pocos)
        {
            systemCountryCodeLogic.Add(pocos);
        }
        public List<SystemCountryCodePoco> GetAllSystemCountryCode()
        {
            return systemCountryCodeLogic.GetAll();
        }
        public SystemCountryCodePoco GetSingleSystemCountryCode(string code)
        {
            return systemCountryCodeLogic.Get(code);
        }
        public void RemoveSystemCountryCode(SystemCountryCodePoco[] pocos)
        {
            systemCountryCodeLogic.Delete(pocos);
        }
        public void UpdateSystemCountryCode(SystemCountryCodePoco[] pocos)
        {
            systemCountryCodeLogic.Update(pocos);
        }//

        //SystemLanguageCode

        public void AddSystemLanguageCode(SystemLanguageCodePoco[] pocos)
        {
            SystemLanguageCodeLogic.Add(pocos);
        }
        public List<SystemLanguageCodePoco> GetAllSystemLanguageCode()
        {
            return SystemLanguageCodeLogic.GetAll();
        }
        public SystemLanguageCodePoco GetSingleSystemLanguageCode(string lid)
        {
            return SystemLanguageCodeLogic.Get(lid);
        }

        public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] pocos)
        {
            SystemLanguageCodeLogic.Delete(pocos);
        }
        public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] pocos)
        {
            SystemLanguageCodeLogic.Update(pocos);
        }
    }
}
