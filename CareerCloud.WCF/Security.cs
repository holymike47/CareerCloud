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
    public class Security : ISecurity
    {
        private SecurityLoginLogic securityLoginLogic;
        private SecurityLoginsLogLogic securityLoginsLogLogic;
        private SecurityLoginsRoleLogic securityLoginsRoleLogic;
        private SecurityRoleLogic securityRoleLogic;
        public Security()
        {
            securityLoginLogic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
            securityLoginsLogLogic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
            securityLoginsRoleLogic = new SecurityLoginsRoleLogic(new EFGenericRepository<SecurityLoginsRolePoco>(false));
            securityRoleLogic = new SecurityRoleLogic(new EFGenericRepository<SecurityRolePoco>(false));
        }
        public void AddSecurityLogin(SecurityLoginPoco[] pocos)
        {
            securityLoginLogic.Add(pocos);
        }

        public List<SecurityLoginPoco> GetAllSecurityLogin()
        {
            return securityLoginLogic.GetAll();
        }

        public SecurityLoginPoco GetSingleSecurityLogin(string id)
        {
            return securityLoginLogic.Get(Guid.Parse(id));
        }

        public void RemoveSecurityLogin(SecurityLoginPoco[] pocos)
        {
            securityLoginLogic.Delete(pocos);
        }

        public void UpdateSecurityLogin(SecurityLoginPoco[] pocos)
        {
            securityLoginLogic.Update(pocos);
        }

        //SecurityLoginsLog
     
        public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] pocos)
        {
            securityLoginsLogLogic.Add(pocos);
        }
        
        public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
        {
            return securityLoginsLogLogic.GetAll();
        }
       
        public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string id)
        {
            return securityLoginsLogLogic.Get(Guid.Parse(id));
        }
        
        public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] pocos)
        {
            securityLoginsLogLogic.Delete(pocos);
        }
        
        public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] pocos)
        {
            securityLoginsLogLogic.Update(pocos);
        }//

        ////SecurityLoginsRole
        public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] pocos)
        {
            securityLoginsRoleLogic.Add(pocos);
        }

        public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole()
        {
            return securityLoginsRoleLogic.GetAll();
        }

        public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string id)
        {
            return securityLoginsRoleLogic.Get(Guid.Parse(id));
        }

        public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] pocos)
        {
            securityLoginsRoleLogic.Delete(pocos);
        }

        public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] pocos)
        {
            securityLoginsRoleLogic.Update(pocos);
        }//

        //SecurityRole
        public void AddSecurityRole(SecurityRolePoco[] pocos)
        {
            securityRoleLogic.Add(pocos);
        }

        public List<SecurityRolePoco> GetAllSecurityRole()
        {
            return securityRoleLogic.GetAll();
        }

        public SecurityRolePoco GetSingleSecurityRole(string id)
        {
            return securityRoleLogic.Get(Guid.Parse(id));
        }

        public void RemoveSecurityRole(SecurityRolePoco[] pocos)
        {
            securityRoleLogic.Delete(pocos);
        }

        public void UpdateSecurityRole(SecurityRolePoco[] pocos)
        {
            securityRoleLogic.Update(pocos);
        }


    }
}
