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
    public class SystemCountryCodeController : ApiController
    {
        private SystemCountryCodeLogic _logic;
        public SystemCountryCodeController()
        {
            _logic = new SystemCountryCodeLogic(new EFGenericRepository<SystemCountryCodePoco>(false));
        }
        [Route("countrycode/{SystemCountryCode}")]
        [HttpGet, ResponseType(typeof(SystemCountryCodePoco))]
        public IHttpActionResult GetSystemCountryCode(string SystemCountryCode)
        {
            try
            {
                SystemCountryCodePoco poco = _logic.Get(SystemCountryCode);
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
        [Route("countrycode")]
        [HttpGet, ResponseType(typeof(List<SystemCountryCodePoco>))]
        public IHttpActionResult GetSystemCountryCode()
        {
            try
            {
                List<SystemCountryCodePoco> pocos = _logic.GetAll();
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
        [Route("countrycode")]
        [HttpPut]
        public IHttpActionResult PutSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
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
        [Route("countrycode")]
        [HttpPost]
        public IHttpActionResult PostSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
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
        [Route("countrycode")]
        [HttpDelete]
        public IHttpActionResult DeleteSystemCountryCode([FromBody] SystemCountryCodePoco[] pocos)
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
