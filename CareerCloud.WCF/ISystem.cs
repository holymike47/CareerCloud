using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
    [ServiceContract]
    interface ISystem
    {
        [OperationContract]
        void AddSystemCountryCode(SystemCountryCodePoco[] pocos);
        [OperationContract]
        List<SystemCountryCodePoco> GetAllSystemCountryCode();
        [OperationContract]
        SystemCountryCodePoco GetSingleSystemCountryCode(string code);
        [OperationContract]
        void RemoveSystemCountryCode(SystemCountryCodePoco[] pocos);
        [OperationContract]
        void UpdateSystemCountryCode(SystemCountryCodePoco[] pocos);


        //
        [OperationContract]
        void AddSystemLanguageCode(SystemLanguageCodePoco[] pocos);
        [OperationContract]
        List<SystemLanguageCodePoco> GetAllSystemLanguageCode();
        [OperationContract]
        SystemLanguageCodePoco GetSingleSystemLanguageCode(string lid);
        [OperationContract]
        void RemoveSystemLanguageCode(SystemLanguageCodePoco[] pocos);
        [OperationContract]
        void UpdateSystemLanguageCode(SystemLanguageCodePoco[] pocos);

    }
}
