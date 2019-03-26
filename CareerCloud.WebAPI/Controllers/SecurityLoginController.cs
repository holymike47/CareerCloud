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
    public class SecurityLoginController : ApiController
    {
        private SecurityLoginLogic _logic;
        public SecurityLoginController()
        {
            _logic = new SecurityLoginLogic(new EFGenericRepository<SecurityLoginPoco>(false));
        }
        [Route("login/{SecurityLoginId}")]
        [HttpGet, ResponseType(typeof(SecurityLoginPoco))]
        public IHttpActionResult GetSecurityLogin(Guid SecurityLoginId)
        {
            try
            {
                SecurityLoginPoco poco = _logic.Get(SecurityLoginId);
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
        [Route("login")]
        [HttpGet, ResponseType(typeof(List<SecurityLoginPoco>))]
        public IHttpActionResult GetSecurityLogin()
        {
            try
            {
                List<SecurityLoginPoco> pocos = _logic.GetAll();
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
        [Route("login")]
        [HttpPut]
        public IHttpActionResult PutSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
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
        [Route("login")]
        [HttpPost]
        public IHttpActionResult PostSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
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
        [Route("login")]
        [HttpDelete]
        public IHttpActionResult DeleteSecurityLogin([FromBody] SecurityLoginPoco[] pocos)
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
