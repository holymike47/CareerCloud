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
    [RoutePrefix("api/careercloud/security/v1")]
    public class SecurityLoginsLogController : ApiController
    {
        private SecurityLoginsLogLogic _logic;
        public SecurityLoginsLogController()
        {
            _logic = new SecurityLoginsLogLogic(new EFGenericRepository<SecurityLoginsLogPoco>(false));
        }
        [Route("loginslog/{SecurityLoginsLogId}")]
        [HttpGet, ResponseType(typeof(SecurityLoginsLogPoco))]
        public IHttpActionResult GetSecurityLoginLog(Guid SecurityLoginsLogId)
        {
            try
            {
                SecurityLoginsLogPoco poco = _logic.Get(SecurityLoginsLogId);
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
        [Route("loginslog")]
        [HttpGet, ResponseType(typeof(List<SecurityLoginsLogPoco>))]
        public IHttpActionResult GetSecurityLoginLog()
        {
            try
            {
                List<SecurityLoginsLogPoco> pocos = _logic.GetAll();
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
        [Route("loginslog")]
        [HttpPut]
        public IHttpActionResult PutSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
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
        [Route("loginslog")]
        [HttpPost]
        public IHttpActionResult PostSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
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
        [Route("loginslog")]
        [HttpDelete]
        public IHttpActionResult DeleteSecurityLoginLog([FromBody] SecurityLoginsLogPoco[] pocos)
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
