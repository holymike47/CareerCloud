using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
    [RoutePrefix("api/careercloud/system/v1")]
    public class SystemLanguageCodeController : ApiController
    {
        private SystemLanguageCodeLogic _logic;
        public SystemLanguageCodeController()
        {
            _logic = new SystemLanguageCodeLogic(new EFGenericRepository<SystemLanguageCodePoco>(false));
        }
        [Route("languagecode/{SystemLanguageCode}")]
        [HttpGet, ResponseType(typeof(SystemLanguageCodePoco))]
        public IHttpActionResult GetSystemLanguageCode(string SystemLanguageCode)
        {
            try
            {
                SystemLanguageCodePoco poco = _logic.Get(SystemLanguageCode);
                if (poco == null)
                {
                    return NotFound();
                }
                return Ok(poco);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("languagecode")]
        [HttpGet, ResponseType(typeof(List<SystemLanguageCodePoco>))]
        public IHttpActionResult GetSystemLanguageCode()
        {
            try
            {
                List<SystemLanguageCodePoco> pocos = _logic.GetAll();
                if (pocos == null)
                {
                    return NotFound();
                }
                return Ok(pocos);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("languagecode")]
        [HttpPut]
        public IHttpActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            try
            {
                _logic.Update(pocos);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("languagecode")]
        [HttpPost]
        public IHttpActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            try
            {
                _logic.Add(pocos);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
        [Route("languagecode")]
        [HttpDelete]
        public IHttpActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
        {
            try
            {
                _logic.Delete(pocos);
                return Ok();
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
